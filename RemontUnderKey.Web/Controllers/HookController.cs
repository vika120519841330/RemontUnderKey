using System.Linq;
using System.Net;
using System.Web.Http;
using ViberAPI;
using ViberAPI.Enums;
using ViberAPI.Models.MessageTypes;

namespace RemontUnderKey.Web.Controllers
{
    public class HookController : ApiController
    {
        ViberWebhook webhook = new ViberWebhook(
            authToken: "4a716aadb067d444-822a77e31aa08d4f-84f0c888d1a5e200",
            endpoint: "https://remontunderkey.azurewebsites.net/hook/receiveMessage",
            subscription: Subscription.Subscribed | Subscription.ConversationStarted);

        [HttpPost]
        public HttpStatusCode ReceiveMessage(string message)
        {
            return HttpStatusCode.OK;
        }

        [HttpGet]
        public string RegisterWebhook()
        {
            return webhook.Register().ToString();
        }

        [HttpGet]
        public string Post(string message)
        {
            Message post = new Message()
            {
                auth_token = webhook.AuthToken,
                from = webhook.GetPublicAccountInfo().members.FirstOrDefault(x => x.role == "admin").id,
                type = "text",
                text = message
            };
            return webhook.Post(post);
        }
    }
}
