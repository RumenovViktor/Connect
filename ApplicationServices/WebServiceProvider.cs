using Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace ApplicationServices
{
    public static class WebServiceProvider<T> where T : ICommand
    {
        public static T Get(T command)
        {
            return default(T);
        }

        public static T Post(T command)
        {
            var envelope = new { command = command };
            var serializedCommand = JsonConvert.SerializeObject(envelope);
            string response = null;
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    response = client.UploadString("http://localhost:51246/api/registration/register/" + command.GetType().Name, "POST", serializedCommand);

                }
            }
            catch (WebException e)
            {
                Debug.Fail("Faild sending request to API.\n");
                throw;
            }

            return default(T);
        }
    }
}
