using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ViberAPI;
using ViberAPI.Enums;
using ViberAPI.Models.DTO;
using ViberAPI.Models.MessageTypes;

namespace RemontUnderKey.Web.Controllers
{
    public class HookController : ApiController
    {
        ViberWebhook webhook = new ViberWebhook(
            authToken: "4a716aadb067d444-822a77e31aa08d4f-84f0c888d1a5e200",
            endpoint: "https://remontunderkey.azurewebsites.net/api/hook/receivemessage",
            subscription: Subscription.All);

        [HttpPost]
        [Route(@"api/hook/receivemessage")] // webhook uri part
        public async Task<OkResult> ReceiveMessage([FromBody]RegistrationResponse1 message)
        {
            //return HttpStatusCode.OK;
            return Ok();
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
