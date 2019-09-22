using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class TypeOfObject_View
    {
        // Идентификатор
        public int Id { get; set; }
        //Наименование типа обьекта ремонта
        public string TitleOfTypeOfObject { get; set; }
        //Описание типа обьекта ремонта
        public string DescriptionOfTypeOfObject { get; set; }

    }
}
