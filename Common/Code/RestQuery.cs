//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Threading.Tasks;
//using Common.Extensions;
////#if NETFRAMEWORK
//using System.Globalization;
//using System.Web;
////#endif
//using Newtonsoft.Json;
//using RestSharp;

//namespace Common.Code
//{
//    public static class RestQuery
//    {
//        private const int Timeout = 200000;

////#if NETFRAMEWORK
//        public static ApiResponse<T> Execute<T>(string apiUrl,
//                                                string resource,
//                                                Method method,
//                                                object content = null,
//                                                Dictionary<string, string> headers = default,
//                                                JsonSerializerSettings jsonSettings = default)
//        {
//            jsonSettings = jsonSettings ?? Settings.JsonSetings;
//            var apiRequest = GenerateRequest(resource, method, content, headers);
//            //var client = new RestClient(apiUrl)
//            //{
//            //    Timeout = Timeout,
//            //    Authenticator = new JwtAuthenticator(Constants.JwtApiToken)
//            //};
//            client.UseSerializer(() => new JsonNetSerializer(jsonSettings));
//            var response = client.Execute(apiRequest);
//            var apiResponse = ProceedResponse<T>(response, jsonSettings);
//            return apiResponse;
//        }
////#endif

//        public static async Task<ApiResponse<T>> ExecuteAsync<T>(string apiUrl,
//                                                                 string resource,
//                                                                 Method method,
//                                                                 object content = null,
//                                                                 Dictionary<string, string> headers = default,
//                                                                 // ReSharper disable once RedundantAssignment
//                                                                 string jwtToken = default,
//                                                                 JsonSerializerSettings jsonSettings = default,
//                                                                 bool useProxy = false)
//        {
//            jsonSettings = jsonSettings ?? Settings.JsonSetings;

////#if NETFRAMEWORK
////            jwtToken = jwtToken ?? Constants.JwtApiToken;
////#endif
//            var apiRequest = GenerateRequest(resource, method, content, headers);
//            var restClient = new RestClient(apiUrl)
//            {
//                Timeout = Timeout
//            };
//            restClient.UseSerializer(() => new JsonNetSerializer(jsonSettings));
//            //if (!string.IsNullOrEmpty(jwtToken))
//            //    restClient.Authenticator = new JwtAuthenticator(jwtToken);

//            //if (useProxy)
//            //{
//            //    restClient.Proxy = new WebProxy(Constants.ProxyIp, Constants.ProxyPort)
//            //    {
//            //        UseDefaultCredentials = false,
//            //        Credentials = new NetworkCredential(Constants.ProxyLogin, Constants.ProxyPassword)
//            //    };
//            //}

//            var response = await restClient.ExecuteAsync(apiRequest);
//            var apiResponse = ProceedResponse<T>(response, jsonSettings);
//            return apiResponse;
//        }

//        private static RestRequest GenerateRequest(string resource,
//                                                   Method method,
//                                                   object content = null,
//                                                   Dictionary<string, string> headers = default)
//        {
//            if (headers is null)
//                headers = new Dictionary<string, string>();

//            var apiRequest = new RestRequest(resource, method, DataFormat.Json);

//            if (content != null)
//                apiRequest.AddJsonBody(content);

//            foreach (var header in headers)
//                AddHeader(header.Key, header.Value);

////#if NETFRAMEWORK
//            var currentContext = System.Web.HttpContext.Current;
//            var isWebApp = currentContext != null;
//            if (isWebApp)
//            {
//                if (!headers.ContainsKey(Constants.HeaderUserLogin))
//                    AddHeader(Constants.HeaderUserLogin, currentContext.User.Identity.Name);
//                if (!headers.ContainsKey(Constants.HeaderUserTimeZome))
//                    AddHeader(Constants.HeaderUserTimeZome, currentContext.Session?[Constants.HeaderUserTimeZome]?.ToString() ?? currentContext.Request.Headers[Constants.HeaderUserTimeZome]);
//            }
//            else
//            {
//                if (!headers.ContainsKey(Constants.HeaderUserTimeZome))
//                    AddHeader(Constants.HeaderUserTimeZome, DateTimeOffset.Now.Offset.TotalHours.ToString(CultureInfo.InvariantCulture));
//            }
////#endif

//            return apiRequest;

//            void AddHeader(string key, string value)
//            {
//                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
//                    apiRequest.AddHeader(key, value);
//            }
//        }

//        private static ApiResponse<T> ProceedResponse<T>(IRestResponse response, JsonSerializerSettings jsonSettings = default)
//        {
//            var apiResponse = new ApiResponse<T>
//            {
//                Code = HttpStatusCode.BadRequest,
//                Message = "Р”Р°РЅРЅС‹Рµ РЅРµ РїРѕР»СѓС‡РµРЅС‹"
//            };

//            if (response.ResponseStatus == ResponseStatus.TimedOut)
//            {
//                apiResponse.Code = HttpStatusCode.RequestTimeout;
//                apiResponse.Message =
//                    $"РџСЂРµРІС‹С€РµРЅРёРµ РІСЂРµРјРµРЅРё РѕР¶РёРґР°РЅРёСЏ РѕС‚РІРµС‚Р° ({CommonHelper.WordNumberCase(Timeout / 1000, " СЃРµРєСѓРЅРґР°", " СЃРµРєСѓРЅРґС‹", " СЃРµРєСѓРЅРґ", true)}).";
//            }

//            if (response.Content.IsNullOrEmpty())
//                return apiResponse;

////#if NETFRAMEWORK
//            response.Content = response.Content.Replace(", System.Private.CoreLib", ", mscorlib");
////#endif
//            try
//            {
//                apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content, jsonSettings);
//            }
//            catch (Exception ex)
//            {
//                apiResponse.Message = ex.Message;
//            }

//            return apiResponse;
//        }
//    }
//}