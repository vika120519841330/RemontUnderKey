﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Infrastructure.Models
{
    public class KindOfJob_Infra
    {
        // Идентификатор
        public int Id { get; set; }
        //Наименование вида ремонтных работ
        public string TitleOfKindOfJob { get; set; }
        //Описание вида ремонтных работ
        public string DescriptionOfKindOfJob { get; set; }
    }
}
