using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class BaseResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
