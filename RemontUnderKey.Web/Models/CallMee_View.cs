using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web;

namespace RemontUnderKey.Web.Models
{
    public class CallMee_View
    {
        private string name;
        private string phone;
        private DateTime datestamp;

        public int Id { get; set; }

        //Если пользователь зарегистрированный - имя пользователя будет заполняться автоматически
        public string Name
        {
            get
            {
                if (name != null)
                {
                    return name;
                }
                else return "Введите имя, по которому к Вам можно обращаться";
            }
            set
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    name = HttpContext.Current.User.Identity.Name;
                }
                else name = value;
            }
        }

        //Если пользователь при регистрации фиксировал телефонный номер - тел.номер будет заполняться автоматически
        public string Telephone
        {
            get
            {
                if (phone != null)
                {
                    return phone;
                }
                else return "Введите номер телефона для связи";
            }
            set
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDbContext()));

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var temp = userManager.GetPhoneNumber(userManager.FindByName(HttpContext.Current.User.Identity.GetUserName()).ToString());
                    if (phone != null)
                    {
                        phone = temp;
                    }
                    else phone = value;
                }
                else phone = value;
            }
        }

        //Отметка времени поступления заявки на обратный звонок от заинтересованноого пользователя
        public DateTime DateStamp
        {
            get
            {
                return datestamp;
            }
            set
            {
                datestamp = HttpContext.Current.Timestamp;
            }
        }
        //Комментарии админа касательно обратного звонка
        public string Comments { get; set; }
        // Отметка о произведенном обратном звонке
        public bool CallIsDone { get; set; }

    }
}
