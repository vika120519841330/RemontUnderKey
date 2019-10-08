using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class Stage_Infra_Domain
    {
        public static Stage_Domain StageFromInfraToDomain(this Stage_Infra @this)
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
        public static Stage_Infra StageFromDomainToInfra(this Stage_Domain @this)
        {
            if (@this != null)
            {
                return new Stage_Infra()
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
