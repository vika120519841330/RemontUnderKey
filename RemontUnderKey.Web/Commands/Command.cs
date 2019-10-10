using RemontUnderKey.Web.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RemontUnderKey.Web.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        // метод принимает в кач.параметров сообщение с командой и экземпляр с телеграмм-бот-клиентом, чтобы была возм-ть отправить ответ обратно
        public abstract void Execute(Message message, TelegramBotClient client);

        // метод сопоставляет команду, введенную пользователем с текущей командой (сопоставление по 2-м параметрам - по имени нашей команды и имени нашего бота)
        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }
    }
}