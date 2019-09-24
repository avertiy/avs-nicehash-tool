namespace AVS.Nicehash.Api
{
    public class CoinInfo
    {
        public string CoinName;
        public AlgoEnum Algorithm;
        public int BlockCount;
        public double Difficulty;
        public double BlockReward;
        /// <summary>
        /// in BTC
        /// </summary>
        public double Price;
    }
}