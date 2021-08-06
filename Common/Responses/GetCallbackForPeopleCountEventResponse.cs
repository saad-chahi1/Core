using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetCallbackForPeopleCountEventResponse : BaseResponse
    {
        [JsonProperty("event_index")]
        public int EventIndex { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("camno")]
        public int Camno { get; set; }

        [JsonProperty("total in")]
        public int TotalIn { get; set; }

        [JsonProperty("total out")]
        public int TotalOut { get; set; }
    }
}
