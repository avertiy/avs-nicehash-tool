using System;

namespace AVS.Nicehash.Api
{
    public static class NiceHashCalculator
    {
        public static double CalculateProfitability(this CoinInfo c, HashPower hashPower)
        {
            //Formula P = h*t*R / (Pow(2,32)*D)
            //Bob buys a dedicated mining computer which can perform a billion hash calculations per second, 
            //h = 1 Ghash /s = pow(10,9) hash 
            //If he uses it to mine continuously for a day (24*60*60 seconds) 
            //when the difficulty is D = 1690906 and the block reward is R = 50 BTC,
            //he will find on average h x t / (pow(2,32)xD) = pow(10,9) hash/s * 86400s / pow(2,32)*1690906 ≈ 0.0119 blocks 
            //and receive payment of 0.0119xR = 0.595 BTC on average.

            var power = Math.Pow(10, 9);
            if(hashPower == HashPower.TeraHash)
                power = Math.Pow(10, 12);

            double ht = power * 86400;
            double blocks = ht / (c.Difficulty * Math.Pow(2.0, 32));
            double earning = c.BlockReward * blocks;
            double earningInBTC = earning * c.Price;

            //Subtract NiceHash service fees
            earningInBTC -= 0.04 * earningInBTC;
            // Subtract min % profit we want to get.
            earningInBTC -= 0.01 * earningInBTC;
            
            earningInBTC = Math.Round(earningInBTC, 5, MidpointRounding.AwayFromZero);

            return earningInBTC;
        }
    }
}