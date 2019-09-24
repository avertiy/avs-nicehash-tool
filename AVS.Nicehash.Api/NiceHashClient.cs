using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVS.CoreLib.ClientApi;

namespace AVS.Nicehash.Api
{
    public class NiceHashClient
    {
        public readonly PrivateApiTools PrivateApiClient;
        public readonly PublicApiTools PublicApi;
        public readonly CoinwarzApiTools CoinwarzApi;
        
        public NiceHashClient(string apiId, string key)
        {
            PrivateApiClient = new PrivateApiTools(new PublicApiClient()
                {
                    BaseUrl = "https://api.nicehash.com/",
                    RelativeUrl = $"api?id={apiId}&key={key}&method="
                });

            PublicApi = new PublicApiTools(new PublicApiClient()
            {
                BaseUrl = "https://api.nicehash.com/",
                RelativeUrl = "api?method="
            });
            CoinwarzApi = new CoinwarzApiTools(new PublicApiClient()
            {
                BaseUrl = "https://www.coinwarz.com/v1/api/coininformation/",
                RelativeUrl = "?apikey=ff69cd468ee04982b9c5eb693e32d9c0&cointag="
            });
        }
    }
}
