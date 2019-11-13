using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class TypeOfObject_View
    {
        // Идентификатор
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер:", IsRequired = false, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        //Наименование типа обьекта ремонта
        [ConfigurationProperty("Тип обьекта ремонта:", IsRequired = true, DefaultValue = "Выберите тип обьекта")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        [Required(ErrorMessage = "Выберите тип обьекта !")]
        public string TitleOfTypeOfObject { get; set; }

        //Описание типа обьекта ремонта
        [ConfigurationProperty("Описание типа обьекта ремонта:", IsRequired = true, DefaultValue = "Опишите тип обьекта ремонта")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        [Required(ErrorMessage = "Опишите тип обьекта ремонта !")]
        public string DescriptionOfTypeOfObject { get; set; }

        //Путь к картинке(красивой, рекламирующей тип ремонтных работ)
        [ConfigurationProperty("Путь к картинке:", IsRequired = true)]
        [DataType(DataType.ImageUrl)]
        [UIHint("Url")]
        [Required(ErrorMessage = "Укажите путь к картинке !")]
        public string ImgSrc { get; set; }
    }
}
