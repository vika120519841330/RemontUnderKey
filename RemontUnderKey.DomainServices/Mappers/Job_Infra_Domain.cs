using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class Job_Infra_Domain
    {
        public static Job_Domain JobFromInfraToDomain(this Job_Infra @this)
        {
            if (@this != null)
            {
                return new Job_Domain()
                {
                    Id = @this.Id,
                    TitleOfJob = @this.TitleOfJob,
                    PriceOfUnitOfJob = @this.PriceOfUnitOfJob,
                    KindOfJob_DomainId = @this.KindOfJob_InfraId,
                    UnitOfJob_DomainId = @this.UnitOfJob_InfraId
                };
            }
            else
            {
                return null;
            }
        }
        public static Job_Infra JobFromDomainToInfra(this Job_Domain @this)
        {
            if (@this != null)
            {
                return new Job_Infra()
                {
                    Id = @this.Id,
                    TitleOfJob = @this.TitleOfJob,
                    PriceOfUnitOfJob = @this.PriceOfUnitOfJob,
                    KindOfJob_InfraId = @this.KindOfJob_DomainId,
                    UnitOfJob_InfraId = @this.UnitOfJob_DomainId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
