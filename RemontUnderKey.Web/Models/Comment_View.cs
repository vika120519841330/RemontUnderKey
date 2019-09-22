using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Models
{
    public class Comment_View
    {
        public int Id { get; set; }
        public ApplicationUser UserName { get; set; }
        public string MessageFromUser { get; set; }
        // Это свойство будет исп-ся администратором сайта для одобрения публикации отзыва на сайте
        public bool ApprovalForPublishing { get; set; }
    }
}
