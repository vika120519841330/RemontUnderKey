using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class Upload_View
    {
        // Идентификатор
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификатор загруженного файла:", IsRequired = false, IsKey = true)]
        [Display(Name = "Идентификатор загруженного файла:")]
        public int? Id { get; set; }

        //Поле для связи с отзывом, вместе с которым был загружен файл
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификатор отзыва, вместе с которым загружен файл:", IsRequired = false, IsKey = false)]
        [Display(Name = "Идентификатор  отзыва, вместе с которым загружен файл:")]
        public int? Comment_ViewId { get; set; }

        //Коллекция байтовых массивов, каждый из которых будет хранить загруженный файл
        [ConfigurationProperty("Загружаемый файл:", IsRequired = false, DefaultValue = "Выберите файл для последующей загрузки")]
        [DataType(DataType.Upload)]
        [Display(Name = "Загружаемый файл:")]
        public byte[] File { get; set; }

        //Наименование загруженного файла
        [ConfigurationProperty("Наименование файла:", IsRequired = true, DefaultValue = "stone.jpg")]
        [DataType(DataType.Text)]
        [Display(Name = "Наименование файла:")]
        public string FileName { get; set; }

        //MIME-тип загруженного файла
        [ConfigurationProperty("Тип загружаемого файла:", IsRequired = true, DefaultValue = "image/jpg")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип загружаемого файла:")]
        public string FileType { get; set; }

    }
}