using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class SetCamAttributeResponse : BaseResponse
    {
        [JsonProperty("camno")]
        public int Camno { get; set; }

        [JsonProperty("brightness")]
        public int Brightness { get; set; }

        [JsonProperty("brightness_enable")]
        public int BrightnessEnable { get; set; }

        [JsonProperty("contrast")]
        public int Contrast { get; set; }

        [JsonProperty("contrast_enable")]
        public int ContrastEnable { get; set; }

        [JsonProperty("saturation")]
        public int Saturation { get; set; }

        [JsonProperty("saturation_enable")]
        public int SaturationEnable { get; set; }

        [JsonProperty("hue")]
        public int Hue { get; set; }

        [JsonProperty("hue_enable")]
        public int HueEnable { get; set; }
    }
}
