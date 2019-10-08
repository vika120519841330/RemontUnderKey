using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{
    public static class Stage_Domain_View
    {
        public static Stage_View StageFromDomainToView(this Stage_Domain @this)
        {
            if (@this != null)
            {
                return new Stage_View()
                {
                    Id = @this.Id,
                    ImgSrc = @this.ImgSrc,
                    DescriptionOfStage = @this.DescriptionOfStage
                };
            }
            else
            {
                return null;
            }
        }
        public static Stage_Domain StageFromViewToDomain(this Stage_View @this)
        {
            if (@this != null)
            {
                return new Stage_Domain()
                {
                    Id = @this.Id,
                    ImgSrc = @this.ImgSrc,
                    DescriptionOfStage = @this.DescriptionOfStage
                };
            }
            else
            {
                return null;
            }
        }
    }
}
