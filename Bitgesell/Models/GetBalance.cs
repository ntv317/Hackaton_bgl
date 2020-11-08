using System;
using Newtonsoft.Json;

namespace Bitgesell.Models
{
    public class GetBalance
    {
       
            [JsonProperty("result")]
            public GetbalanceResult[] Result { get; set; }

            [JsonProperty("error")]
            public object Error { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
       
        
    }

    public partial class GetbalanceResult
    {
        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("vout")]
        public long Vout { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("scriptPubKey")]
        public string ScriptPubKey { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("spendable")]
        public bool Spendable { get; set; }

        [JsonProperty("solvable")]
        public bool Solvable { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("safe")]
        public bool Safe { get; set; }
    }
}
