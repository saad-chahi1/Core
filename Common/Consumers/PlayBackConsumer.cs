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
    public class PlayBackConsumer
    {
        private readonly HttpClient _httpClient;

        //Constructeur 
        public PlayBackConsumer(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<BaseResponse> Playback(int camera, string stream, string login, string password, int dst, string eventTime)
        {
            try
            {
                var response = await _httpClient.GetAsync("/"+ eventTime + camera+".mp4?id="+login+"&pwd="+password+"&DST ="+dst);
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
