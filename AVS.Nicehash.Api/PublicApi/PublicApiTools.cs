using System.Collections.Generic;
using AVS.CoreLib.ClientApi;
using AVS.Nicehash.Api.Models;
using Newtonsoft.Json;

namespace AVS.Nicehash.Api
{
    public class PublicApiTools: PublicApiToolsBase
    {
        public PublicApiTools(PublicApiClient apiWebClient) : base(apiWebClient)
        {
        }

        public GlobalStats GetGlobalStats(ServersLocation? location)
        {
            var parameters = new List<object>();
            if(location.HasValue)
                parameters.Add("location="+(int)location.Value);

            var data = GetData< NiceHashResponse<GlobalStats>>(PublicApiCommands.GetProfitability, parameters.ToArray());
            return data.Result;
        }

        public OrdersResponse GetOrders(ServersLocation location, AlgoEnum algo)
        {
            var postData = new object[]
            {
                "location="+(int) location,
                "algo="+(int)algo
            };

            var data = GetData<NiceHashResponse<OrdersResponse>>(PublicApiCommands.GetOrders, postData);
            return data.Result;
        }

        public OrdersResponse GetMyOrders(ServersLocation location, AlgoEnum algo)
        {
            var postData = new object[]
            {
                "location="+(int) location,
                "algo="+(int)algo
            };

            var data = GetData<NiceHashResponse<OrdersResponse>>(PublicApiCommands.GetOrders, postData);
            return data.Result;
        }
    }
}