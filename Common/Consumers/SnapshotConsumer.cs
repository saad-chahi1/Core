using Newtonsoft.Json;
using SSI.GeoVision.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SSI.GeoVision.Core.Consumers
{
    class SnapshotConsumer
    {
        private readonly HttpClient _httpClient;

        //Constructeur 
        public SnapshotConsumer(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<BaseResponse> Snapshot(int camera, string imageSize, string login, string password)
        {
            try
            {
                var response = await _httpClient.GetAsync("/"+camera+ imageSize+".jpg?id="+login+"&pwd ="+password);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<BaseResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }
    }
}
