using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class Photo_Infra_Domain
    {
        public static Photo_Domain PhotoFromInfraToDomain(this Photo_Infra @this)
        {
            if (@this != null)
            {
                return new Photo_Domain()
                {
                    Id = @this.Id,
                    ImgSrc = @this.ImgSrc,
                    Repareobject_DomainId = @this.Repareobject_InfraId
                };
            }
            else
            {
                return null;
            }
        }
        public static Photo_Infra PhotoFromDomainToInfra(this Photo_Domain @this)
        {
            if (@this != null)
            {
                return new Photo_Infra()
                {
                    Id = @this.Id,
                    ImgSrc = @this.ImgSrc,
                    Repareobject_InfraId = @this.Repareobject_DomainId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
