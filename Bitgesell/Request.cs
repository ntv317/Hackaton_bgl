using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitgesell
{
    public class Request
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; } = "1.0";

        [JsonProperty("id")]
        public string Id { get; set; } = "CurlText";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public List<string> Parameters { get; set; }
    }
}
