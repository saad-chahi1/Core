using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetPlayListResponse : BaseResponse
    {
        [JsonProperty("camno")]
        public int Camno { get; set; }

        [JsonProperty("starttime")]
        public string StartTime { get; set; }

        [JsonProperty("endtime")]
        public string EndTime { get; set; }

        [JsonProperty("videocount")]
        public int VideoCount { get; set; }

        [JsonProperty("videoroot")]
        public IEnumerable<VideoRootDto> VideoRoot { get; set; }
    }

    public class VideoRootDto
    {

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("filestarttime")]
        public string FileStartTime { get; set; }

        [JsonProperty("DST")]
        public int Dst { get; set; }

        [JsonProperty("fileendtime")]
        public string FileEndTime { get; set; }
    }
}
