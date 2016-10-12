using System.Net;
using System.Diagnostics;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace ApplicationServices
{
    public static class WebServiceProvider<T> where T : class
    {
        public static T Get(string baseApiUrl, IDictionary<string, string> queryParams = null)
        {
            var response = string.Empty;

            try
            {
                using (var client = new WebClient())
                {
                    if (queryParams != null)
                    {
                        foreach (var param in queryParams)
                        {
                            client.QueryString.Add(param.Key, param.Value);
                        }
                    }

                    response = client.DownloadString(baseApiUrl);
                    response = response.Replace(@"\", string.Empty).Trim(new char[] { '\"' });
                }
            }
            catch (WebException e)
            {
                Debug.Fail("Faild sending request to API.\n");
                throw;
            }

            return JsonConvert.DeserializeObject<T>(response);
        }

        public static T Post(T command, string baseApiUrl)
        {
            var envelope = new { command = command };
            var serializedCommand = JsonConvert.SerializeObject(envelope);
            string response = null;
            object executedCommand = null;

            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    response = client.UploadString(baseApiUrl + typeof(T).Name, "POST", serializedCommand);
                    executedCommand = (T)JsonConvert.DeserializeObject(response, typeof(T));
                }
            }
            catch (WebException e)
            {
                Debug.Fail("Faild sending request to API.\n");
                throw;
            }

            return (T)JsonConvert.DeserializeObject(response, typeof(T));
        }
    }
}
