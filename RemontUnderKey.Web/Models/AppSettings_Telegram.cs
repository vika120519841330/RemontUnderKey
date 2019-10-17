using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemontUnderKey.Web.Models
{
    public static class AppSettings_Telegram
    {
        // конечная ссылка на наш опубликованный bot
        public static string Url { get; set; } = "https://remontunderkey.azurewebsites.net:443/{0}";

        // название контакта нашего опубликованного botа
        public static string Name { get; set; } = "repareunderkeybot";

        // api-ключ нашего опубликованного botа
        public static string Key { get; set; } = "818182363:AAE-0U53O7Rz94QWCvZQM0gPRXz8hm8_OfQ";

    }
}