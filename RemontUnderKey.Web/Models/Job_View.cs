using RemontUnderKey.Web.Attributes;
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
    public class Job_View
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер:", IsRequired = false, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        [Display(Name = "Вид работы:")]
        [ConfigurationProperty("Вид работы:", IsRequired = true, DefaultValue = "Укажите наименование вида работы !")]
        [UIHint("String")]
        [Required(ErrorMessage = "Укажите наименование вида работы")]
        public string TitleOfJob { get; set; }

        [Display(Name = "Стоимость, долл. по курсу НБ РБ:")]
        [ConfigurationProperty("Стоимость, долл. по курсу НБ РБ:", IsRequired = true, DefaultValue = "Укажите стоимость в долл. !")]
        [UIHint("Decimal")]
        [Required(ErrorMessage = "Укажите стоимость в у.е. !")]
        public double PriceOfUnitOfJob { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Разновидность работ:")]
        [ConfigurationProperty("Разновидность работ:", IsRequired = true, IsKey = false)]
        [Required(ErrorMessage = "Укажите разновидность работ !")]

        public int KindOfJob_ViewId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Единица измерения:")]
        [ConfigurationProperty("Единица измерения:", IsRequired = true, IsKey = false)]
        [Required(ErrorMessage = "Укажите единицу измерения !")]
        public int UnitOfJob_ViewId { get; set; }

    }
}
