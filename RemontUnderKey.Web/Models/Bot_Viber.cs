using System.Threading.Tasks;
using System;
using Viber.Bot;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RemontUnderKey.Web.Models
{
    public static class Bot_Viber
    {
        private static ViberBotClient client;
        // метод возвращает экземпляр ViberBot-клиента
        public async static Task<ViberBotClient> Get()
        {
            // проверяем заинициализированно ли поле client
            if (client != null)
            {
                return client;
            }
            // создаем новый экземпляр с viber-токеном, который сохранен в статическом классе AppSettings
            client = new ViberBotClient(AppSettings_Viber.AuthToken);

            // настройка webhook-сервиса, размещённого по https-адресу, который будет обрабатывать изменения.
            var hook = AppSettings_Viber.Url;
            await client.SetWebhookAsync(
                url: hook,
                eventTypes: null
                );
            return client;
        }
    }
}