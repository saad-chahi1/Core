using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetCallbackForMotionEventResponse : BaseResponse
    {
        [JsonProperty("event_index")]
        public int EventIndex { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("maskcammotion")]
        public int MaskCammotion { get; set; }

    }
}
