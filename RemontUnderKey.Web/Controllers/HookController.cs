using System.Collections.Generic;
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
                //идентификатор подписанного на паблик-бот пользователя, которому бот будет отправлять сообщение
                receiver = "7OWqiq04a3iq6Y/pO2c/yw==",
                //receiver = webhook.GetPublicAccountInfo().members.FirstOrDefault(x => x.role == "admin").id,
                sender = new Sender
                {
                    name = "remontunderkey"
                },
                type = "text",
                text = message
            };
            return webhook.Post(post);
        }

        //вспомогательный метод - возвращает идентификаторы всех участниках публичного вайбер-аккаунта
        IEnumerable<string> ListOfIdMembers;
        [HttpGet]
        [Route(@"api/hook/getallidmembers")] 
        public IEnumerable<string> GetAllIdMembers()
        {
            ListOfIdMembers = webhook.GetPublicAccountInfo().members.Select(_ => _.id);
            return ListOfIdMembers;
        }

        //вспомогательный метод - возвращает всю инф-цию обо всех участниках публичного вайбер-аккаунта
        IEnumerable<MemberDTO> ListOfMembers;
        [HttpGet]
        [Route(@"api/hook/getallmembers")]
        public IEnumerable<MemberDTO> GetAllMembers()
        {
            ListOfMembers = webhook.GetPublicAccountInfo().members.ToArray<MemberDTO>();
            return ListOfMembers;
        }

    }
}
