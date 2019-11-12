using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Infrastructure.Models
{
    public class Job_Infra
    {
        public int Id { get; set; }
        public string TitleOfJob { get; set; }
        public double PriceOfUnitOfJob { get; set; }
        // Это свойство будет использоваться как внешний ключ
        public int KindOfJob_InfraId { get; set; }
        // Это свойство будет использоваться как внешний ключ
        public int UnitOfJob_InfraId { get; set; }

    }
}
