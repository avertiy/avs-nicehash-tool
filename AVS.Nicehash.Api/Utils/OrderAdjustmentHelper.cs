using System;
using System.Collections.Generic;
using System.Linq;
using AVS.Nicehash.Api.Models;

namespace AVS.Nicehash.Api.Utils
{
    public class OrderAdjustmentHelper
    {
        private readonly NiceHashClient _nicehash;

        public static int IdleIterations;
        //private List<Order> _allOrders;
        //private List<Order> _myOrders;
        public OrderAdjustmentHelper(NiceHashClient nicehash)
        {
            _nicehash = nicehash;
        }

        public Result ProcessOrder(Order myOrder, List<Order> marketOrders)
        {
            var res = new Result();
            if (marketOrders == null || marketOrders.Count ==0)
            {
                res.Error = "No market orders";
                return res;
            }

            double priceLimit = 0.0165;
            double priceChange = 0.0001;
            if (myOrder.Workers == 0)
            {
                if(IdleIterations ==0)
                    IdleIterations++;
                var ordersBelow = marketOrders.Where(o => o.Price < myOrder.Price).ToArray();
                if (ordersBelow.Length < 1)
                {
                    if (myOrder.Price < priceLimit)
                    {
                        var newPrice = myOrder.Price + priceChange; 
                        res = _nicehash.PrivateApiClient.OrderPriceIncrease(myOrder, newPrice);
                        IdleIterations = 0;
                    }
                    else
                    {
                        if (IdleIterations > 1)
                        {
                            //increase price but set limit minimal
                            var newPrice = myOrder.Price + priceChange;
                            res = _nicehash.PrivateApiClient.OrderPriceIncrease(myOrder, newPrice);
                            var minspeed = 0.01;
                            res = _nicehash.PrivateApiClient.OrderSetLimit(myOrder, minspeed);
                            IdleIterations = 0;
                        }
                        else res.Error = $"Order price has reached the price limit {priceLimit:0.0000}";
                    }
                }
            }
            else
            {
                IdleIterations = 0;
                var ordersBelow = marketOrders.Where(o => o.Price < myOrder.Price).ToArray();
                var totalSpeed = ordersBelow.Sum(o => o.AcceptedSpeed);
                var totalWorkers = ordersBelow.Sum(o => o.Workers);
                if (totalSpeed > myOrder.AcceptedSpeed * 50 && totalWorkers > 50)
                {
                    var newPrice = myOrder.Price - priceChange;
                    res = _nicehash.PrivateApiClient.OrderPriceDecrease(myOrder, newPrice);
                    if (newPrice < priceLimit)
                    {
                        if(newPrice < 0.015)
                            res = _nicehash.PrivateApiClient.OrderSetLimit(myOrder, 0.03);
                        else
                            res = _nicehash.PrivateApiClient.OrderSetLimit(myOrder, 0.02);
                    }
                }
                else
                {
                    res.Message = $"Order price {myOrder.Price:0.0000} is OK";
                }
            }

            return res;
        }
    }
}