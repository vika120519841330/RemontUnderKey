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
    public class PhotoGalery_View
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

        //Путь к миниатюрной картинке
        [ConfigurationProperty("Путь к миниатюрной картинке:", IsRequired = true)]
        [DataType(DataType.ImageUrl)]
        [UIHint("Url")]
        public string ImgSrcMini { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер обьекта ремонта:", IsRequired = true, IsKey = false)]
        [Display(Name = "Идентификационный номер обьекта ремонта:")]
        public int Repareobject_ViewId { get; set; }

        [ConfigurationProperty("Наименование обьекта ремонта:", IsRequired = true, DefaultValue = "Укажите наименование обьекта ремонта")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        public string TitleOfRepareObject { get; set; }
    }
}
