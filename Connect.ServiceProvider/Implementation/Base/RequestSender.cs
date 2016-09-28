namespace Connect.ServiceProvider
{
    using System;
    using System.Net.Http;
    using System.Configuration;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Net;

    using Newtonsoft.Json;
    
    public abstract class RequestSender<T> : IRequestSender<T>
    {
        private static string apiUrl = ConfigurationManager.AppSettings["apiUrl"].ToString();

        public virtual async Task<T> Get(T command)
        {
            //var deserializedUser = default(T);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(apiUrl);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var serializedUser = await response.Content.ReadAsStringAsync();
            //        deserializedUser = (T)JsonConvert.DeserializeObject(serializedUser);
            //    }
            //}

            //return deserializedUser;
            return default(T);
        }

        public virtual T Post(T command)
        {
            var response = string.Empty;
            apiUrl = string.Format(apiUrl, "Registration", "Register");

            var serializedCommand = JsonConvert.SerializeObject(command);

            using (var client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var uri = new Uri(apiUrl);
                    response = client.UploadString(apiUrl, serializedCommand);
                }
                catch (WebException ex)
                {
                    throw new HttpRequestException("Request to API failed.", ex.InnerException);
                }
            }

            return JsonConvert.DeserializeObject(response);
        }
    }
}