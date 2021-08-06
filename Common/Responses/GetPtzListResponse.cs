using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetPtzListResponse : BaseResponse
    {
        [JsonProperty("ptz_mask1")]
        public int PtzMask1 { get; set; }

        [JsonProperty("ptz_mask2")]
        public int PtzMask2 { get; set; }
    }
}
