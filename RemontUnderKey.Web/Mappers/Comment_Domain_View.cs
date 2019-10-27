using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{
    public static class Comment_Domain_View
    {
        public static Comment_View CommentFromDomainToView(this Comment_Domain @this)
        {
            if (@this != null)
            {
                return new Comment_View()
                {
                    Id = @this.Id,
                    UserName = @this.UserName,
                    UserId = @this.UserId,
                    MessageFromUser = @this.MessageFromUser,
                    ApprovalForPublishing = @this.ApprovalForPublishing
                };
            }
            else
            {
                return null;
            }
        }
        public static Comment_Domain CommentFromViewToDomain(this Comment_View @this)
        {
            if (@this != null)
            {
                return new Comment_Domain()
                {
                    Id = @this.Id,
                    UserName = @this.UserName,
                    UserId = @this.UserId,
                    MessageFromUser = @this.MessageFromUser,
                    ApprovalForPublishing = @this.ApprovalForPublishing
                };
            }
            else
            {
                return null;
            }
        }
    }
}
