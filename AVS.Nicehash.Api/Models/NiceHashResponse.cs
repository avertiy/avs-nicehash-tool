using System.Collections.Generic;
using Newtonsoft.Json;

namespace AVS.Nicehash.Api.Models
{
    public class NiceHashResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
    }

    public class Result
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("success")]
        public string Message { get; set; }
        public bool Success => string.IsNullOrEmpty(Error) && !string.IsNullOrEmpty(Message);

        public override string ToString()
        {
            return Success ? $"Success - {Message}": $"Fail - {Error}";
        }
    }


    public class GlobalStats 
    {
        [JsonProperty("stats")]
        public List<StatItem> Stats { get; set; }
    }

    public class StatItem
    {
        [JsonProperty("profitability_above_ltc")]
        public string ProfitabilityAbove { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("profitability_ltc")]
        public string Profitability { get; set; }
        [JsonProperty("algo")]
        public int Algo { get; set; }

        public AlgoEnum Algorithm => (AlgoEnum) Algo;

        [JsonProperty("speed")]
        public string Speed { get; set; }

        public override string ToString()
        {
            return $"{Algo} {Speed} price: {Price} profitability: {Profitability} / {ProfitabilityAbove}";
        }
    }


    public class OrdersResponse 
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        //"type":0,"id":5877,"price":"0.0505","algo":1,"alive":true,"limit_speed":"1.0","workers":0,"accepted_speed":0.0}
        [JsonProperty("type")]
        public int TypeInt { get; set; }

        public OrderType Type => (OrderType) TypeInt;

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("algo")]
        public int Algo { get; set; }

        public AlgoEnum Algorithm => (AlgoEnum)Algo;

        [JsonProperty("alive")]
        public bool IsAlive { get; set; }
        [JsonProperty("limit_speed")]
        public double SpeedLimit { get; set; }
        [JsonProperty("workers")]
        public int Workers { get; set; }
        [JsonProperty("accepted_speed")]
        public double AcceptedSpeed { get; set; }

        public override string ToString()
        {
            return $"Order {Algorithm} {Type} price: {Price} speed: {SpeedLimit}/{AcceptedSpeed} workers: {Workers}";
        }
    }
}