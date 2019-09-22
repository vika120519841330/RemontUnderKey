using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class Repareobject_View
    {
        public int Id { get; set; }
        //Адрес/наименование строительного обьекта
        public string AddressOfRepareobject { get; set; }
        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("TypeOfObject_View")]
        public int? TypeOfObject_ViewId { get; set; }
    }
}
