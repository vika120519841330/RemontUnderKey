using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class Photo_View
    {
        public int Id { get; set; }

        //Путь к картинке
        public string ImgSrc { get; set; } 

        //Путь к миниатюрной картинке
        public string ImgSrcMini { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("Repareobject_View")]
        public int Repareobject_ViewId { get; set; }
    }
}
