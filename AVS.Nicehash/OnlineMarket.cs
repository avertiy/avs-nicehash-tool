using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AVS.CoreLib.WinForms.Controls;
using AVS.CoreLib.WinForms.Grid;
using AVS.CoreLib.WinForms.MVC;
using AVS.CoreLib.WinForms.Utils;
using AVS.Nicehash.Api;
using AVS.Nicehash.Api.Models;

namespace AVS.Nicehash
{
    public partial class OnlineMarket : UserControlEx, IGridView
    {
        public IGridControl GridControl => gridControl1;
        public ISummaryView SummaryView => null;
        public ISelectedCellsSummaryView SelectedCellsSummaryView => null;

        public GridColorScheme MyOrdersColorScheme => gridControl1.Hightlighter.Schemes.First();
        public GridColorScheme PriceColorScheme => gridControl1.Hightlighter.Schemes[1];

        protected override void Initialize()
        {
            InitializeComponent();
            gridControl1.Controller = GetController<OnlineMarketViewController>();
            var colorScheme = new GridColorScheme()
            {
                ColumnIndex = gridControl1.Columns["ColumnOrder"].Index,
                Scope = ColorSchemeScope.RowBackColor,
                Colors = new[] {Color.Orange} 
            }.WithEquityCondition();
            gridControl1.Hightlighter.AddScheme(colorScheme);

            var priceScheme = new GridColorScheme()
            {
                ColumnIndex = gridControl1.Columns["ColumnPrice"].Index,
                Scope = ColorSchemeScope.RowForeColor,
                Colors = new[] { System.Drawing.SystemColors.Window, Color.Blue }
            }.WithDefaultCondition();
            gridControl1.Hightlighter.AddScheme(priceScheme);
        }

        public void LoadData(ServersLocation location, AlgoEnum algo, double profitablePrice)
        {
            var tuple = new Tuple<ServersLocation,AlgoEnum,double>(location,algo,profitablePrice);
            gridControl1.RunLoadDataAsync(tuple);
        }
    }

    public class OnlineMarketViewController : GridViewController<OnlineMarket, Order>
    {
        private readonly NiceHashClient _nicehash;

        public OnlineMarketViewController(NiceHashClient nicehash)
        {
            _nicehash = nicehash;
        }

        public override object LoadData(object argument)
        {
            var tuple = (Tuple<ServersLocation, AlgoEnum, double>)argument;
            var location = tuple.Item1;
            var algo = tuple.Item2;
            var profitablePrice = tuple.Item3;
            this.View.PriceColorScheme.Values = new[]{profitablePrice};
            var res = _nicehash.PublicApi.GetOrders(location, algo);
            List<Order> orders = res.Orders.Where(o => o.Workers > 0).ToList();
            var response = _nicehash.PrivateApiClient.GetMyOrders(location, algo);
            if (response.Orders.Count > 0)
            {
                List<int> ids = new List<int>();
                foreach (var order in response.Orders)
                {
                    ids.Add(order.Id);
                    if (orders.Any(o => o.Id == order.Id))
                        continue;
                    orders.Add(order);
                }
                this.View.MyOrdersColorScheme.Values = ids.ToArray();
            }
            return orders;
        }
    }
}
