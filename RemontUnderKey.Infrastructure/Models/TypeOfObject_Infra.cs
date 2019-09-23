using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Infrastructure.Models
{
    public class TypeOfObject_Infra
    {
        // Идентификатор
        public int Id { get; set; }
        //Наименование типа обьекта ремонта
        public string TitleOfTypeOfObject { get; set; }
        //Описание типа обьекта ремонта
        public string DescriptionOfTypeOfObject { get; set; }
    }
}
