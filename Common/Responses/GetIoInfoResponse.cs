using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetIoInfoResponse :BaseResponse
    {
        [JsonProperty("moduleno")]
        public int Moduleno { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("inputpincount")]
        public int InputPinCount { get; set; }

        [JsonProperty("outputpincount")]
        public int OutPutPinCount { get; set; }
    }
}
