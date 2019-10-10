using System.Threading.Tasks;
using Telegram.Bot;
using RemontUnderKey.Web.Commands;
using System.Collections.Generic;

namespace RemontUnderKey.Web.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
        // свойство, которое будет хранить коллекцию команд
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        // метод возвращает экземпляр клиента
        public async static Task<TelegramBotClient> Get()
        {
            // проверяем заинициализированно ли поле client
            if (client != null)
            {
                return client;
            }

            // инициализация всех существующих команд
            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            // TODO: add more commands

            {
                // создаем новый экземпляр с api-ключом, который записан в статическом классе AppSettings
                client = new TelegramBotClient(AppSettings.Key);
                var hook = string.Format(AppSettings.Url, "api/message/update");
                await client.SetWebhookAsync(hook);
                return client;
            }
        }

    }
}