using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class Job_View
    {
        [Key]
        [Display(Name = "Идентификационный номер")]
        public int Id { get; set; }

        [Display(Name = "Виды работ")]
        public string TitleOfJob { get; set; }

        [Display(Name = "Стоимость, долл. по курсу НБ РБ")]
        public double PriceOfUnitOfJob { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("KindOfJob_View")]
        public int? KindOfJob_ViewId { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [Display(Name = "Единица измерения")]
        [ForeignKey("UnitOfJob_View")]
        public int? UnitOfJob_ViewId { get; set; }

    }
}
