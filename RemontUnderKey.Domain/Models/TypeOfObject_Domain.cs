using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Domain.Models
{
    public class TypeOfObject_Domain
    {
        // Идентификатор
        public int Id { get; set; }

        //Наименование типа обьекта ремонта
        public string TitleOfTypeOfObject { get; set; }

        //Описание типа обьекта ремонта
        public string DescriptionOfTypeOfObject { get; set; }

        //Путь к картинке(красивой, рекламирующей тип ремонтных работ)
        public string ImgSrc { get; set; }
    }
}
