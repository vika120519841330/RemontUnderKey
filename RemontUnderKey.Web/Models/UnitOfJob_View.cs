using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class UnitOfJob_View
    {
        public int Id { get; set; }
        public string TitleOfUnit { get; set; }
    }
}
