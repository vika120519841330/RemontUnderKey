using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Domain.Models
{
    public class Job_Domain
    {
        public int Id { get; set; }
        public string TitleOfJob { get; set; }
        public double PriceOfUnitOfJob { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("KindOfJob_Domain")]
        public int? KindOfJob_DomainId { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("UnitOfJob_Domain")]
        public int? UnitOfJob_DomainId { get; set; }

    }
}
