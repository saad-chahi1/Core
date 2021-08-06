using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetCallbackForHumanVehicleDetectionEventResponse : BaseResponse
    {
        [JsonProperty("event_index")]
        public int EventIndex { get; set; }

        [JsonProperty("camno")]
        public int Camno { get; set; }

        [JsonProperty("timeslist_start")]
        public string TimeslistStart { get; set; }

        [JsonProperty("timeslist_end")]
        public string TimeslistEnd { get; set; }

        [JsonProperty("listnum")]
        public int ListNum { get; set; }

        [JsonProperty("list")]
        public IEnumerable<ListRootDto> ListRoot { get; set; }
    }

    public class ListRootDto
    {

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("dst")]
        public bool Dst { get; set; }

        [JsonProperty("info")]
        public IEnumerable<InfoRootDto> InfoRoot { get; set; }
    }

    public class InfoRootDto
    {

        [JsonProperty("upperbodycolor1")]
        public int UpperBodyColor1 { get; set; }

        [JsonProperty("upperbodycolor2")]
        public int UpperBodyColor2 { get; set; }

        [JsonProperty("upperbodycolor3")]
        public int UpperBodyColor3 { get; set; }

        [JsonProperty("lowerbodycolor1")]
        public int LowerBodyColor1 { get; set; }

        [JsonProperty("lowerbodycolor2")]
        public int LowerBodyColor2 { get; set; }

        [JsonProperty("lowerbodycolor3")]
        public int LowerBodyColor3 { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("img")]
        public string Image { get; set; }

    }
}
