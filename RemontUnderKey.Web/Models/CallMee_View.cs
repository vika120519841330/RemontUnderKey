using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class CallMee_View
    {
        [HiddenInput(DisplayValue = false)]
        [ConfigurationProperty("Идентификатор", IsRequired = true, IsKey = true)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Заполните поле с именем!")]
        [Display(Name = "Ваше имя:")]
        [ConfigurationProperty("Ваше имя:", IsRequired = true, DefaultValue = "Введите имя, по которому к Вам можно будет обратиться")]
        [DataType(DataType.Text)]
        public string Name  { get; set; }

        [RegularExpression(@"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$", ErrorMessage = "Номер телефона должен иметь формат +375хxxxxxxxx \n или 8029xxxxxxx")]
        [Required(ErrorMessage = "Заполните поле с номером телефона для обратной связи!", AllowEmptyStrings = false)]
        [Display(Name = "Телефонный номер:")]
        [ConfigurationProperty("Телефонный номер:", IsRequired = true, DefaultValue = "Введите номер телефона для обратной связи")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        //Отметка времени поступления заявки на обратный звонок от заинтересованноого пользователя
        [Display(Name = "Дата поступления заявки на обратный звонок:")]
        [ConfigurationProperty("Дата поступления заявки на обратный звонок:", IsRequired = false)]
        [DataType(DataType.DateTime)]
        public DateTime DateStamp { get; set; }

        //Комментарии касательно обратного звонка
        [Display(Name = "Вопрос или комментарий:")]
        [ConfigurationProperty("Вопрос или комментарий:", IsRequired = false, DefaultValue = "Задайте вопрос или оставьте свой комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        // Отметка о произведенном обратном звонке (по умолчанию булев тип имеет значение false)
        [Display(Name = "Обратный звонок произведен:")]
        [ConfigurationProperty("Обратный звонок произведен:", IsRequired = false, DefaultValue = "Отметьте флажок, в случае произведенного обратного звонка")]
        [UIHint("Boolean")]
        public bool CallIsDone { get; set; } = false;

    }
}
