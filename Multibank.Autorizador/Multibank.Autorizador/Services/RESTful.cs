using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Multibank.Autorizador.Models;

namespace Multibank.Autorizador.Services
{

    public class RESTful<T>
    {

        public async Task<BaseResponse<Session>> TokenRegistrationAsync(string urlAction, string userName, string pasword)
        {
            var result = new BaseResponse<Session>();

            try
            {
                using (var client = new HttpClient())
                {
                    var req = new HttpRequestMessage(HttpMethod.Post, $"{Settings.ServiceBaseUrl}{urlAction}")
                    {
                        Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("username", userName),
                            new KeyValuePair<string, string>("password", pasword),
                            new KeyValuePair<string, string>("grant_type", "password")
                        })
                    };
                    var response = await client.SendAsync(req);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result.Data = JsonConvert.DeserializeObject<Session>(content);
                        result.Success = true;
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result.Data = JsonConvert.DeserializeObject<Session>(content);
                        result.Error = result.Data.error_description;
                        result.Success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task<BaseResponse<T>> HttpClientResponseAsync(string urlAction, HttpMethod method, List<KeyValuePair<string, string>> parameters)
        {
            var result = new BaseResponse<T>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Settings.CurrentSession?.token_type ?? "", Settings.CurrentSession?.access_token ?? "");
                    var urlBase = Settings.ServiceBaseUrl;
                    var req = new HttpRequestMessage(method, $"{urlBase}{urlAction}");
                    if (parameters != null)
                        req.Content = new FormUrlEncodedContent(parameters);
                    var response = await client.SendAsync(req);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<BaseResponse<T>>(content);
                    }
                    else
                    {
                        result.Success = false;
                        result.Error = response.StatusCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
            }

            return result;
        }
    }
}
