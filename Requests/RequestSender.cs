using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Requests
{
    public class RequestSender<T>
    {
        public T Get(IDictionary<string, string> commandQueryString, string apiUrl)
        {
            var response = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    foreach (var param in commandQueryString)
                    {
                        client.QueryString.Add(param.Key, param.Value);
                    }

                    response = client.DownloadString(apiUrl);
                }
            }
            catch (WebException ex)
            {
                throw new HttpRequestException("Error calling API", ex.InnerException);
            }

            return (T)JsonConvert.DeserializeObject(response, typeof(T));
        }

        public T Post(T command, string apiUrl)
        {
            var response = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    response = client.UploadString(apiUrl, "POST", JsonConvert.SerializeObject(command));
                }
            }
            catch (WebException ex)
            {
                throw new HttpRequestException("Error calling API.\n", ex.InnerException);
            }

            return (T)JsonConvert.DeserializeObject(response, typeof(T));
        }
    }
}
