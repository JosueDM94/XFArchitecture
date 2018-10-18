using System;
using System.Net;
using System.Text;
using System.Net.Http;

using Newtonsoft.Json;
using Microsoft.AppCenter.Crashes;

using XFArchitecture.Core.Models;
using XFArchitecture.Core.Utilities;
using XFArchitecture.Core.Extensions;
using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Core.Services.Repository.Consumer
{
    public class BaseConsumer
    {
        protected HttpClient Client { get; set; }
        protected INetworkService NetworkService { get; set; }

        public BaseConsumer(INetworkService networkService)
        {
            NetworkService = networkService;
            Client = new HttpClient()
            {
                MaxResponseContentBufferSize = Constants.MaxResponseContentBufferSize,
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        protected Uri GetWSURL() => Constants.BASE_URI;

        protected T MakeGetCall<T>(string urlFormat)
        {
            Func<T> f = () =>
            {
                try
                {
                    var response = Client.GetAsync(urlFormat).Result;
                    if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        Crashes.TrackError(new Exception(result));
                        var errorEntity = JsonConvert.DeserializeObject<BaseEntity>(result);
                        if (!string.IsNullOrEmpty(errorEntity.Message))
                            throw new Exception(errorEntity.Message);
                        else
                            throw new Exception(Messages.GeneralErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    throw new Exception(Messages.GeneralErrorMessage);
                }
            };
            return NetworkService.RunFunction(f);
        }

        protected T MakePostCall<T>(string urlFormat, dynamic myObj, bool isOauth = false)
        {
            Func<T> f = () =>
            {
                try
                {
                    string strContent = JsonConvert.SerializeObject(myObj);
                    var response = Client.PostAsync(urlFormat, new StringContent(strContent, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;
                        return (isOauth) ? (T)Convert.ChangeType(strResult, typeof(string)) : JsonConvert.DeserializeObject<T>(strResult);
                    }
                    else
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        var errorEntity = JsonConvert.DeserializeObject<BaseEntity>(result);
                        Crashes.TrackError(new Exception(result), StringExtension.ToDictionary(Messages.ErrorTitle, myObj));
                        if (!string.IsNullOrEmpty(errorEntity.Message))
                            throw new Exception(errorEntity.Message);
                        else
                            throw new Exception(Messages.GeneralErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    throw new Exception(Messages.GeneralErrorMessage);
                }
            };
            return NetworkService.RunFunction(f);
        }

        protected T MakePutCall<T>(string urlFormat, dynamic myObj)
        {
            Func<T> f = () =>
            {
                try
                {
                    string strContent = JsonConvert.SerializeObject(myObj);
                    var response = Client.PutAsync(urlFormat, new StringContent(strContent, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        var errorEntity = JsonConvert.DeserializeObject<BaseEntity>(result);
                        Crashes.TrackError(new Exception(result), StringExtension.ToDictionary(Messages.ErrorTitle, myObj));
                        if (!string.IsNullOrEmpty(errorEntity.Message))
                            throw new Exception(errorEntity.Message);
                        else
                            throw new Exception(Messages.GeneralErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    throw new Exception(Messages.GeneralErrorMessage);
                }
            };
            return NetworkService.RunFunction(f);
        }

        protected T MakeDeleteCall<T>(string urlFormat)
        {
            Func<T> f = () =>
            {
                try
                {
                    var response = Client.DeleteAsync(urlFormat).Result;
                    if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        Crashes.TrackError(new Exception(result));
                        var errorEntity = JsonConvert.DeserializeObject<BaseEntity>(result);
                        if (!string.IsNullOrEmpty(errorEntity.Message))
                            throw new Exception(errorEntity.Message);
                        else
                            throw new Exception(Messages.GeneralErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                    throw new Exception(Messages.GeneralErrorMessage);
                }
            };
            return NetworkService.RunFunction(f);
        }
    }
}
