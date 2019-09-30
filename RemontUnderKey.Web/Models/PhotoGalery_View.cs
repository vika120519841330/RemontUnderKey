using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class PhotoGalery_View
    {
        public int Id { get; set; }

        //Путь к картинке
        public string ImgSrc { get; set; } 

        //Путь к миниатюрной картинке
        public string ImgSrcMini { get; set; }
        public int? Repareobject_ViewId { get; set; }
        public string TitleOfRepareObject { get; set; }

    }
}
