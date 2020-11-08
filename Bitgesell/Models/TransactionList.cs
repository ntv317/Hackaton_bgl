using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitgesell.Models
{
    public class TransactionList
    {
        
            [JsonProperty("result")]
            public  List< Result> TransactionResult { get; set; }

            [JsonProperty("error")]
            public object Error { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

    public partial class Result
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("vout")]
        public long Vout { get; set; }

        [JsonProperty("confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("blockhash")]
        public string Blockhash { get; set; }

        [JsonProperty("blockheight")]
        public long Blockheight { get; set; }

        [JsonProperty("blockindex")]
        public long Blockindex { get; set; }

        [JsonProperty("blocktime")]
        public long Blocktime { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("walletconflicts")]
        public object[] Walletconflicts { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("timereceived")]
        public long Timereceived { get; set; }

        [JsonProperty("bip125-replaceable")]
        public string Bip125Replaceable { get; set; }

      
        

    }


}
