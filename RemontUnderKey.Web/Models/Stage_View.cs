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
    public class Stage_View
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер:", IsRequired = true, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        //Путь к картинке
        [ConfigurationProperty("Путь к картинке:", IsRequired = true)]
        [DataType(DataType.ImageUrl)]
        [UIHint("Url")]
        public string ImgSrc { get; set; }

        //Содержание этапа работ
        [ConfigurationProperty("Содержание этапа работ:", IsRequired = true, DefaultValue = "Укажите содержание этапа работ")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        public string DescriptionOfStage { get; set; }

    }
}
