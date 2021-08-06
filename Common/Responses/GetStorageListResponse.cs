using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Responses
{
    public class GetStorageListResponse : BaseResponse
    {
        [JsonProperty("storageroot")]
        public IEnumerable<StorageRootDto> StorageRoot { get; set; }
    }

    public class StorageRootDto
    {

        [JsonProperty("storagename")]
        public string StorageName { get; set; }

        [JsonProperty("storagepath")]
        public string StoragePath { get; set; }

        [JsonProperty("freespace")]
        public int FreeSpace { get; set; }

        [JsonProperty("totalspace")]
        public int TotalSpace { get; set; }

        [JsonProperty("camcount")]
        public int CamCount { get; set; }

        [JsonProperty("camno")]
        public string Camno { get; set; }
    }
}
