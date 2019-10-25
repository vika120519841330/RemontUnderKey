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
    public class KindOfJob_View
    {
        // Идентификатор
        [Key]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        [ConfigurationProperty("Идентификационный номер:", IsRequired = true, IsKey = true)]
        [Display(Name = "Идентификационный номер:")]
        public int Id { get; set; }

        //Наименование разновидности ремонтных работ
        [ConfigurationProperty("Разновидность ремонтных работ:", IsRequired = true, DefaultValue = "Выберите разновидность ремонтных работ")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        public string TitleOfKindOfJob { get; set; }

        //Описание разновидности ремонтных работ
        [ConfigurationProperty("Описание разновидности ремонтных работ:", IsRequired = true, DefaultValue = "Укажите описание разновидности ремонтных работ")]
        [DataType(DataType.Text)]
        [UIHint("String")]
        public string DescriptionOfKindOfJob { get; set; }
    }
}
