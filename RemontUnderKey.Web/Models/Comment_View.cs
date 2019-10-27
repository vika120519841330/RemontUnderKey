using System.Security.Principal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class Comment_View
    {
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер", IsRequired = true, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        [ConfigurationProperty("Имя пользователя:", IsRequired = false, DefaultValue = "Имя пользователя")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        [Display(Name = "Имя пользователя:")]
        public string UserName { get; set; } 

        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификатор пользователя", IsRequired = false, IsKey = false)]
        [Display(Name = "Идентификатор пользователя:")]
        [UIHint("String")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Оставьте свой отзыв!")]
        [ConfigurationProperty("Отзыв пользователя:", IsRequired = true, DefaultValue = "Оставьте свой отзыв")]
        [DataType(DataType.MultilineText)]
        [UIHint("MultilineText")]
        [Display(Name = "Отзыв пользователя:")]
        public string MessageFromUser { get; set; }

        // Это свойство будет исп-ся администратором сайта для одобрения публикации отзыва на сайте
        [ConfigurationProperty("Отметка о модерации отзыва:", IsRequired = false, DefaultValue = "Отметьте флажок в случае публикации отзыва")]
        [UIHint("Boolean")]
        [Display(Name = "Отметка о модерации отзыва:")]
        public bool ApprovalForPublishing { get; set; } = false;
    }
}
