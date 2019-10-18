using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI.Models.DTO
{
    public class WebhookSettingsDTO
    {
        public string url { get; set; }
        public List<string> event_types { get; set; }

    }
}
