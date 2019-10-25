using System;
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
    public class Repareobject_View
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер:", IsRequired = true, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        //Адрес/наименование строительного обьекта
        [ConfigurationProperty("Наименование обьекта ремонта:", IsRequired = true, DefaultValue = "Укажите наименование обьекта ремонта")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        public string AddressOfRepareobject { get; set; }

        [ConfigurationProperty("Тип обьекта ремонта:", IsRequired = true, DefaultValue = "Выберите тип обьекта ремонта")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        public int TypeOfObject_ViewId { get; set; }
    }
}
