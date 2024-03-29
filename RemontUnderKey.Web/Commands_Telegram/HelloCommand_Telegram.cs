﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace RemontUnderKey.Web.Commands_Telegram
{
    public class HelloCommand_Telegram : Command_Telegram
    {
        // имя команды
        public override string Name => "hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            // отправка текстового сообщения (в кач. параметров - ChatId, текстовое сообщение для пользователя и аргумент replyToMessageId
            // для цитирования отправленного пользователем сообщения)
            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId)
                .ConfigureAwait(false);
        }
    }
}