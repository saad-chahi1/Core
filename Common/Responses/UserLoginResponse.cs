using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SSI.GeoVision.Core.Responses
{
	
	public class UserLoginResponse : BaseResponse
    {

		[JsonProperty("key")]
		public String Key { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }

		[JsonProperty("video_port")]
		public int VideoPort { get; set; }
	}
}
