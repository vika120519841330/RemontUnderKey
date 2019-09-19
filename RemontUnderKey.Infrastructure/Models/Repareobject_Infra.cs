using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Infrastructure.Models
{
    public class Repareobject_Infra
    {
        public int Id { get; set; }
        //Адрес/наименование строительного обьекта
        public string AddressOfRepareobject { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("TypeOfObject_Infra")]
        public int? TypeOfObject_InfraId { get; set; }
    }
}
