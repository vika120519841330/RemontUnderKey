using Newtonsoft.Json;
using System.IO;
using System.Net;
using ViberAPI.Enums;
using ViberAPI.Models.DTO;
using ViberAPI.Models.MessageTypes;
using ViberAPI.Models.WebhookModels;

namespace ViberAPI
{
    public class ViberWebhook
    {
        public string AuthToken { get; }
        public string EndpointRoute { get; }
        public Subscription Subscription { get; set; }
        public ViberWebhook(string authToken, string endpoint, Subscription subscription)
        {
            AuthToken = authToken;
            EndpointRoute = endpoint;
            Subscription = subscription;
        }

        public StatusCode Register()
        {
            WebhookSettings settings = new WebhookSettings()
            {
                Url = EndpointRoute,
                Subscription = Subscription
            };
            string json = JsonConvert.SerializeObject((WebhookSettingsDTO)settings);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://chatapi.viber.com/pa/set_webhook");
            httpWebRequest.Headers.Add("X-Viber-Auth-Token", AuthToken);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            RegistrationResponse info = JsonConvert.DeserializeObject<RegistrationResponse>(result);
            return (StatusCode)info.status;
        }
        public PublicAccountInfoDTO GetPublicAccountInfo()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://chatapi.viber.com/pa/get_account_info");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var info = new { auth_token = AuthToken };
            var json = JsonConvert.SerializeObject(info);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            var accountInfo = JsonConvert.DeserializeObject<PublicAccountInfoDTO>(result);
            return accountInfo;
        }
        public string Post(Message message)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://chatapi.viber.com/pa/send_message");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var json = JsonConvert.SerializeObject(message);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
