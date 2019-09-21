using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class KindOfJob_Infra_Domain
    {
        public static KindOfJob_Domain KindOfJobFromInfraToDomain(this KindOfJob_Infra @this)
        {
            if (@this != null)
            {
                return new KindOfJob_Domain()
                {
                    Id = @this.Id,
                    TitleOfKindOfJob = @this.TitleOfKindOfJob,
                    DescriptionOfKindOfJob = @this.DescriptionOfKindOfJob
                };
            }
            else
            {
                return null;
            }
        }
        public static KindOfJob_Infra KindOfJobFromDomainToInfra(this KindOfJob_Domain @this)
        {
            if (@this != null)
            {
                return new KindOfJob_Infra()
                {
                    Id = @this.Id,
                    TitleOfKindOfJob = @this.TitleOfKindOfJob,
                    DescriptionOfKindOfJob = @this.DescriptionOfKindOfJob
                };
            }
            else
            {
                return null;
            }
        }
    }
}
