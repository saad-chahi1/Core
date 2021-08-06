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
    public class LiveConsumer
    {
        private readonly HttpClient _httpClient;

        //Constructeur 
        public LiveConsumer(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<BaseResponse> Live(string camera, string stream)
        {
            try
            {
                var response = await _httpClient.GetAsync("/"+camera+"_"+stream);
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
