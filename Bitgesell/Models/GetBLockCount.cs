using System;
using Newtonsoft.Json;

namespace Bitgesell.Models
{
    public class GetBLockCount
    {
        [JsonProperty("result")]
        public long Result { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
