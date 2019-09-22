using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class Job_View
    {
        public int Id { get; set; }
        public string TitleOfJob { get; set; }
        public double PriceOfUnitOfJob { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("KindOfJob_View")]
        public int? KindOfJob_ViewId { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("UnitOfJob_View")]
        public int? UnitOfJob_ViewId { get; set; }

    }
}
