using System.Threading.Tasks;
using Telegram.Bot;
using RemontUnderKey.Web.Commands_Telegram;
using System.Collections.Generic;
using System;

namespace RemontUnderKey.Web.Models
{
    public static class Bot_Telegram
    {
        private static TelegramBotClient client;
        private static List<Command_Telegram> commandsList;
        // свойство, которое будет хранить коллекцию команд
        public static IReadOnlyList<Command_Telegram> Commands { get => commandsList.AsReadOnly(); }

        // метод возвращает экземпляр клиента
        public async static Task<TelegramBotClient> Get()
        {
            // проверяем заинициализированно ли поле client
            if (client != null)
            {
                return client;
            }

            // инициализация всех существующих команд
            commandsList = new List<Command_Telegram>();
            commandsList.Add(new HelloCommand_Telegram());
            // TODO: add more commands

            // создаем новый экземпляр с api-ключом, который записан в статическом классе AppSettings
            client = new TelegramBotClient(AppSettings_Telegram.Key) { Timeout = TimeSpan.FromSeconds(10)};
            // настройка webhook-сервиса, размещённого по https-адресу, который будет обрабатывать изменения - этот способ меньше нагружает сервер Telegram.
            var hook = string.Format(AppSettings_Telegram.Url, "api/message/update");
            await client.SetWebhookAsync(hook);
            return client;
        }
    }
}