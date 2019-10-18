using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI.Models.DTO
{
    public class RegistrationResponse
    {
        public int status { get; set; }
        public string status_message { get; set; }
        public List<string> event_types { get; set; }
    }
}
