using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class LiveRtspResponse : BaseResponse
    {
        [JsonProperty("RTSProot")]
        public IEnumerable<RtspRootDto> RtspRoot { get; set; }
    }

    public class RtspRootDto {

        [JsonProperty("id")]
        public int Id {get; set; }

        [JsonProperty("stream1")]
        public string Stream1 { get; set; }

        [JsonProperty("stream2")]
        public string Stream2 { get; set; }
    }


    
}
