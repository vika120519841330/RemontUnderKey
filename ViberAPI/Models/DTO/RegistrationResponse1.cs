using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI.Models.DTO
{
    public class RegistrationResponse1
    {
        public string event_types { get; set; }
        public long timestamp { get; set; }
        public long message_token { get; set; }
    }
}
