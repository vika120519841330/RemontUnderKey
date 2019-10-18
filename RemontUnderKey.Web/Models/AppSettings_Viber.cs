using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemontUnderKey.Web.Models
{
    public static class AppSettings_Viber
    {
        // конечная ссылка на наш опубликованный bot
        public static string Url { get; set; } = "https://remontunderkey.azurewebsites.net:443/api/viber/update";

        // наименование паблик-аккаунта
        public static string AccountName { get; set; } = "remontunderkey";

        // viber-token 
        public static string AuthToken { get; set; } = "4a716aadb067d444-822a77e31aa08d4f-84f0c888d1a5e200";

        // администратор паблик-аккаунта
        public static string Admin { get; set; } = "VikaStrigo";

    }
}