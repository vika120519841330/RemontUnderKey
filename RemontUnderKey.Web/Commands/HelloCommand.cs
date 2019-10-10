using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RemontUnderKey.Web.Commands
{
    public class HelloCommand : Command
    {
        // имя команды
        public override string Name => "hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            // отправка текстового сообщения (в кач. параметров - ChatId, текстовое сообщение для пользователя и аргумент replyToMessageId
            // для цитирования отправленного пользователем сообщения)
            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}