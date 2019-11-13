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
    public class UnitOfJob_View
    {
        // Идентификатор
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер:", IsRequired = false, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        [ConfigurationProperty("Наименование единицы измерения:", IsRequired = true, DefaultValue = "Выберите единицу измерения:")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        [Required(ErrorMessage = "Выберите единицу измерения !")]
        public string TitleOfUnit { get; set; }
    }
}
