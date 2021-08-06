using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetCallbackForInputOutputResponse : BaseResponse
    {
        [JsonProperty("event_index")]
        public int EventIndex { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("root")]
        public IEnumerable<RootDto> Root { get; set; }
    }

    public class RootDto
    {

        [JsonProperty("moduleno")]
        public int Moduleno { get; set; }

        [JsonProperty("pin")]
        public int Pin { get; set; }
    }
}
