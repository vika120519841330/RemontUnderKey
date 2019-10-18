using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI.Models.DTO
{
    public class PublicAccountInfoDTO
    {
        public string status { get; set; }
        public string status_message { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string icon { get; set; }
        public string background { get; set; }
        public string category { get; set; }
        public string subcategory { get; set; }
        public LocationDTO location { get; set; }
        public string country { get; set; }
        public string webhook { get; set; }
        public List<string> event_types { get; set; }
        public List<MemberDTO> members { get; set; }
    }
}
