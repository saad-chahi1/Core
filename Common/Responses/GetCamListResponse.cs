using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetCamListResponse : BaseResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("cameralistroot")]
        public IEnumerable<CamListRootDto> CameraListRoot { get; set; }

        [JsonProperty("cameragroupcount")]
        public int CameraGroupCount { get; set; }

        [JsonProperty("cameragrouproot")]
        public IEnumerable<CamGroupRootDto> CameraGroupRoot { get; set; }
    }

    public class CamListRootDto
    {

        [JsonProperty("camno")]
        public int Camno { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("modelname")]
        public string ModelName { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class CamGroupRootDto
    {
        [JsonProperty("groupno")]
        public int GroupNo { get; set; }

        [JsonProperty("grouptyp")]
        public int GroupType { get; set; }

        [JsonProperty("groupcount")]
        public int GroupCount { get; set; }

        [JsonProperty("goupcam")]
        public string GoupCam { get; set; }
    }
}
