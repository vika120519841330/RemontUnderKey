using System.Web.Http.Results;
using System.Web.Http;
using Telegram.Bot.Types;
using RemontUnderKey.Web.Models;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Controllers
{
    public class MessageController : ApiController
    {
        // при обращении по этому маршруту будет обрабатываться инф-я, присланная телеграммом
        // в параметре Update содржится актуальная инфо для бота
        [Route(@"api/message/update")] // webhook uri part
        public async Task<OkResult> Update([FromBody] Update update)
        {
            // получим список доступных команд, чтобы в дальнейшем выбрать нужную с помощью цикла foreach
            var commands = Bot_Telegram.Commands;

            // подготовим сообщение для бота
            var message = update.Message;

            // подготовим телеграмм бот-клиент, чтобы отсылать сообщение клиенту
            var client = await Bot_Telegram.Get();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }
            return Ok();
        }
    }
}
