using AVS.CoreLib.ClientApi;
using AVS.Nicehash.Api.Models;

namespace AVS.Nicehash.Api
{
    public class PrivateApiTools : PublicApiToolsBase
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public PrivateApiTools(PublicApiClient apiWebClient) : base(apiWebClient)
        {
        }
        
        public OrdersResponse GetMyOrders(ServersLocation location, AlgoEnum algo)
        {
            var postData = new object[]
            {
                "my=1",
                "location="+(int) location,
                "algo="+(int)algo
            };

            var data = GetData<NiceHashResponse<OrdersResponse>>(PublicApiCommands.GetOrders, postData);
            return data.Result;
        }

        public Result OrderPriceDecrease(Order order, double newPrice)
        {
            var postData = new object[]
            {
                "my=1",
                "algo="+(int)order.Algorithm,
                "order="+order.Id,
                "price="+newPrice
            };
            var data = GetData<NiceHashResponse<Result>>(PublicApiCommands.OrderSetPriceDecrease, postData);
            return data.Result;
        }

        public Result OrderPriceIncrease(Order order, double newPrice)
        {
            var postData = new object[]
            {
                "algo="+(int)order.Algorithm,
                "order="+order.Id,
                "price="+newPrice
            };
            var data = GetData<NiceHashResponse<Result>>(PublicApiCommands.OrderSetPrice, postData);
            //var url = ApiWebClient.LastUrl;
            //var json = ApiWebClient.LastResponse;
            return data.Result;
        }

        public Result OrderSetLimit(Order order, double newLimit)
        {
            var postData = new object[]
            {
                "algo="+(int)order.Algorithm,
                "order="+order.Id,
                "limit="+newLimit
            };
            var data = GetData<NiceHashResponse<Result>>(PublicApiCommands.OrderSetLimit, postData);
            //var url = ApiWebClient.LastUrl;
            //var json = ApiWebClient.LastResponse;
            return data.Result;
        }
    }
}