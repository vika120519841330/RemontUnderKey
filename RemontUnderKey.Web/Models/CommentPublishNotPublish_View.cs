using System.Security.Principal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class CommentPublishNotPublish_View
    {
        public Dictionary<Comment_View, List<Upload_View>> NotPublished{ get; set; }
        public Dictionary<Comment_View, List<Upload_View>> Published { get; set; }
    }
}
