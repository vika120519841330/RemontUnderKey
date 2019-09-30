using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Domain.Models
{
    public class Photo_Domain
    {
        public int Id { get; set; }

        //Путь к картинке
        public string ImgSrc { get; set; }

        //Путь к миниатюрной картинке
        public string ImgSrcMini { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("Repareobject_Domain")]
        public int Repareobject_DomainId { get; set; }
    }
}
