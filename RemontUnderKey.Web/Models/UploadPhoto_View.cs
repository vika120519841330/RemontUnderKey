using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class UploadPhoto_View
    {
        // Идентификатор
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [Display(Name = "Идентификатор загруженного файла:")]
        public int? Id { get; set; }

        //Свойство для связи с обьектом ремонта (по id), к которому относится загружаемое фото
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [Display(Name = "Идентификационный номер обьекта ремонта:")]
        [Required(ErrorMessage = "Выберите обьекта ремонта!")]
        public int Repareobject_ViewId { get; set; }

        //Свойство для связи с обьектом ремонта (по наименованию), к которому относится загружаемое фото
        [DataType(DataType.Text)]
        [UIHint("String")]
        public string TitleOfRepareObject { get; set; }

        //Байтовый массив, который будет хранить загруженный файл
        [DataType(DataType.Upload)]
        [Display(Name = "Загружаемый файл:")]
        [Required(ErrorMessage = "Выберите файл для последующей загрузки!")]
        public byte[] File { get; set; }

        //Наименование загруженного файла
        [DataType(DataType.Text)]
        [Display(Name = "Наименование файла:")]
        public string FileName { get; set; }

        //MIME-тип загруженного файла
        [DataType(DataType.Text)]
        [Display(Name = "Тип загружаемого файла:")]
        public string FileType { get; set; }

    }
}