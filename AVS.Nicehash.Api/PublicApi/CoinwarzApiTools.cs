using System;
using System.Linq;
using AVS.CoreLib.ClientApi;

namespace AVS.Nicehash.Api
{
    public class CoinwarzApiTools : PublicApiToolsBase
    {
        public CoinwarzApiTools(PublicApiClient apiWebClient) : base(apiWebClient)
        {
        }

        public CoinInfo GetCoinInfo(string cointag)
        {
            var data = GetData<CoinwarzResponse>(cointag);
            CoinInfo res = null;
            if (data?.Data != null)
            {
                var rate = data.Data.ExchangeRates.FirstOrDefault(r => r.Exchange == "Poloniex") ?? data.Data.ExchangeRates.First();
                res = new CoinInfo()
                {
                    CoinName = data.Data.CoinName,
                    BlockCount = data.Data.BlockCount,
                    Difficulty = data.Data.Difficulty,
                    BlockReward = data.Data.BlockReward,
                    Price = rate.ToBTC,
                    Algorithm = (AlgoEnum)Enum.Parse(typeof(AlgoEnum), data.Data.Algorithm)
                };
            }
            return res;
        }

    }

    public class CoinwarzResponse
    {
        public bool Success;
        public string Message;
        public DataStruct Data;

        public class DataStruct
        {
            public string CoinName;
            public string CoinTag;
            public int BlockCount;
            public double Difficulty;
            public double BlockReward;
            public bool IsBlockExplorerOnline;
            public bool IsExchangeOnline;
            public string Algorithm;
            public ExchangeRate[] ExchangeRates;
            public double BlockTimeInSeconds;
            public string HealthStatus;
            public string Message;

            public class ExchangeRate
            {
                public string Exchange;
                public double ToUSD;
                public double ToBTC;
                public double Volume;
                public double TimeStamp;
            }
        }

    }
}