using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{
    public static class Photo_Domain_View
    {
        public static Photo_View PhotoFromDomainToView(this Photo_Domain @this)
        {
            if (@this != null)
            {
                return new Photo_View()
                {
                    Id = @this.Id,
                    ImgSrc = @this.ImgSrc,
                    Repareobject_ViewId = @this.Repareobject_DomainId
                };
            }
            else
            {
                return null;
            }
        }
        public static Photo_Domain PhotoFromViewToDomain(this Photo_View @this)
        {
            if (@this != null)
            {
                return new Photo_Domain()
                {
                    Id = @this.Id,
                    ImgSrc = @this.ImgSrc,
                    Repareobject_DomainId = @this.Repareobject_ViewId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
