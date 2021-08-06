using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetPtzInfoResponse : BaseResponse
    {
        [JsonProperty("have_ptz")]
        public bool HavePtz { get; set; }

        [JsonProperty("ptz")]
        public PtzInfoRootDto Ptz { get; set; }
    }

    public class PtzInfoRootDto
    {

        [JsonProperty("bUD")]
        public int Ud { get; set; }

        [JsonProperty("bLR")]
        public int Lr { get; set; }

        [JsonProperty("bHome")]
        public int Home { get; set; }

        [JsonProperty("bZoom")]
        public int Zoom { get; set; }

        [JsonProperty("bFocus")]
        public int Focus { get; set; }

        [JsonProperty("bAutoFocus")]
        public int AutoFocus { get; set; }

        [JsonProperty("bSpeed")]
        public int Speed { get; set; }
    }
}
