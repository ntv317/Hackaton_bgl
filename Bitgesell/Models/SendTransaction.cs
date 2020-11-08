using System;
using Newtonsoft.Json;

namespace Bitgesell.Models
{
    public class SendTransaction
    {
        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
