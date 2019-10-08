using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class Stage_View
    {
        public int Id { get; set; }

        //Путь к картинке
        public string ImgSrc { get; set; }

        //Содержание этапа работ
        public string DescriptionOfStage { get; set; }

    }
}
