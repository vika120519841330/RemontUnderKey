using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Domain.Models
{
    public class Repareobject_Domain
    {
        public int Id { get; set; }
        //Адрес/наименование строительного обьекта
        public string AddressOfRepareobject { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("TypeOfObject_Domain")]
        public int TypeOfObject_DomainId { get; set; }
    }
}
