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
    public class GeoVisionConsumer
    {
        private readonly HttpClient _httpClient;
        
        //Constructeur 
        public GeoVisionConsumer(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<UserLoginResponse> UserLogin(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=user_login&id="+login+"&pwd="+motPass);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserLoginResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<LiveRtspResponse> LiveRtsp(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=live_rtsp&id=" + login + "&pwd=" + motPass);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LiveRtspResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<SetCamAttributeResponse> SetCamAttribute(string login, string motPass, int camIndex, int brightness, int contrast, int saturation, int hue)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=set_cam_attribute&id="+ login +"&pwd =" + motPass+"&cam_index =" + camIndex +"&brightness =" + brightness+"&contrast =" + contrast+"&saturation =" + saturation+" &hue =" +hue);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SetCamAttributeResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCamInfoResponse> GetCamInfo(string login, string motPass, int camIndex)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_cam_info&id=" + login + "&pwd =" + motPass + "&cam_index =" + camIndex);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCamInfoResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCamListResponse> GetCamList(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_cam_list&id=" + login + "&pwd=" + motPass);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCamListResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetPlayListResponse> GetPlayList(string login, string motPass, int camIndex, long timeStart, long timeEnd)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_play_list&id=" + login + "&pwd=" + motPass+ "&cam_index="+ camIndex + "&time_start="+timeStart+"&time_end ="+timeEnd);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetPlayListResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<SetCamMonitorResponse> SetCamMonitor(string login, string motPass, int camIndex, int cmd)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=set_cam_monitor&id=" + login + "&pwd=" + motPass + "&cam_index=" + camIndex + "&cmd=" + cmd );
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SetCamMonitorResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetIoInfoResponse> GetIoInfo(string login, string motPass, int ioIndex)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_io_info&id=" + login + "&pwd=" + motPass + "&io_index=" + ioIndex );
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetIoInfoResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<SetIoCmdResponse> SetIoCmd(string login, string motPass, int ioIndex, int ioCmd)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=set_io_cmd&id=" + login + "&pwd=" + motPass + "&io_index=" + ioIndex + "&io_cmd=" +ioCmd);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    
                    return JsonConvert.DeserializeObject<SetIoCmdResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetPtzInfoResponse> GetPtzInfo(string login, string motPass, int camIndex)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_ptz_info&id=" + login + "&pwd=" + motPass + "&cam_index=" + camIndex);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetPtzInfoResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetPtzListResponse> GetPtzList(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_ptz_list&id=" + login + "&pwd=" + motPass);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetPtzListResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<SetPtzCmdResponse> SetPtzCmd(string login, string motPass, int camIndex, int ptzCmd)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=set_ptz_cmd&id=" + login + "&pwd=" + motPass + "&cam_index=" + camIndex + "&ptz_cmd=" + ptzCmd);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SetPtzCmdResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetStorageListResponse> GetStorageList(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_storage_list&id=" + login + "&pwd=" + motPass);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetStorageListResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCallbackForMotionEventResponse> GetCallbackForMotionEvent(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_callback_event&id=" + login + "&pwd=" + motPass + "&event_index=0");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCallbackForMotionEventResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCallbackForInputOutputResponse> GetCallbackForInputOutputEvent(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_callback_event&id=" + login + "&pwd=" + motPass + "&event_index=1");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCallbackForInputOutputResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCallbackForObjectEventResponse> GetCallbackForObjectEvent(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_callback_event&id=" + login + "&pwd=" + motPass + "&event_index=2");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject< GetCallbackForObjectEventResponse >(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCallbackForPeopleCountEventResponse> GetCallbackForPeopleCountEvent(string login, string motPass)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_callback_event&id=" + login + "&pwd=" + motPass + "&event_index=3");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCallbackForPeopleCountEventResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<GetCallbackForHumanVehicleDetectionEventResponse> GetCallbackForHumanVehicleDetectionEvent(string login, string motPass, int camIndex, long timeStart)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=get_callback_event&id=" + login + "&pwd=" + motPass + "&event_index=150&cam_index="+camIndex+"&time_start="+timeStart);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCallbackForHumanVehicleDetectionEventResponse>(result);
                }
            }
            catch (Exception) { }
            return null;
        }

        public async Task<BaseResponse> Heatmap(string login, string motPass, int camera, int rainbow, long startTime, long endTime)
        {
            try
            {
                var response = await _httpClient.GetAsync("?method=heatmap&cam="+camera+"&ranbow="+rainbow+"&st ="+ startTime + "&et ="+ endTime + "&id ="+login+"&pwd ="+motPass);
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
