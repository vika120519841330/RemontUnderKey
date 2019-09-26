using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class CallMee_View
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "Ваше имя:")]
        public string Name  { get; set; }

        [Display(Name = "Телефонный номер:")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        //Отметка времени поступления заявки на обратный звонок от заинтересованноого пользователя
        [Display(Name = "Дата поступления заявки на обратный звонок:")]
        [DataType(DataType.DateTime)]
        public DateTime DateStamp { get; set; }

        //Комментарии админа касательно обратного звонка
        [Display(Name = "Комментарии касательно сделанного обратного звонка:")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        // Отметка о произведенном обратном звонке (по умолчанию белев тип имеет значение false)
        [Display(Name = "Обратный звонок произведен:")]
        [UIHint("Boolean")]
        public bool CallIsDone { get; set; }

    }
}
