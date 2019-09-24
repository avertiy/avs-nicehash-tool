using System.Linq;
using AVS.CoreLib.Data.Domain.Tasks;
using AVS.CoreLib.Services.Logging.LogWriters;
using AVS.CoreLib.Services.Tasks;
using AVS.Nicehash.Api.Models;
using AVS.Nicehash.Api.Utils;

namespace AVS.Nicehash.Api.Tasks
{
    public class OrderAdjustmentTask : ITask
    {
        public static ScheduleTask DefaultScheduleTask
        {
            get
            {
                var task = new ScheduleTask
                {
                    Name = "Order Adjustment Task",
                    Seconds = 600,//
                    Enabled = true,
                    StopOnError = false,
                    Type = typeof(OrderAdjustmentTask).AssemblyQualifiedName
                };
                return task;
            }
        }
        private readonly NiceHashClient _nicehash;
        private readonly OrderAdjustmentHelper _helper;

        public OrderAdjustmentTask(OrderAdjustmentHelper helper, NiceHashClient nicehash)
        {
            _helper = helper;
            _nicehash = nicehash;
        }

        public void Execute(TaskLogWriter log)
        {
            var location = ServersLocation.Europe;
            var algo = AlgoEnum.X11;
            var allOrdersResponse = _nicehash.PublicApi.GetOrders(location, algo);
            if (allOrdersResponse == null)
            {
                log.Result("GetOrders failed",false);
                return;
            }

            var marketOrders = allOrdersResponse.Orders.Where(o => o.IsAlive && o.Workers > 0).ToList();

            var myOrdersResponse = _nicehash.PrivateApiClient.GetMyOrders(location, algo);
            if (myOrdersResponse == null)
            {
                log.Result("GetMyOrders failed", false);
                return;
            }

            foreach (var myOrder in myOrdersResponse.Orders)
            {
                Result result = _helper.ProcessOrder(myOrder,marketOrders);
                log.Write(result.ToString());
            }

            log.Result(true);
        }
    }
}
