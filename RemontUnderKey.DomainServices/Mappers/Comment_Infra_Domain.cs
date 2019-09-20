using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class Comment_Infra_Domain
    {
        public static Comment_Domain CommentFromInfraToDomain(this Comment_Infra @this)
        {
            if (@this != null)
            {
                return new Comment_Domain()
                {
                    Id = @this.Id,
                    UserName = @this.UserName,
                    MessageFromUser = @this.MessageFromUser,
                    ApprovalForPublishing = @this.ApprovalForPublishing
                };
            }
            else
            {
                return null;
            }
        }
        public static Comment_Infra CommentFromDomainToInfra(this Comment_Domain @this)
        {
            if (@this != null)
            {
                return new Comment_Infra()
                {
                    Id = @this.Id,
                    UserName = @this.UserName,
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
