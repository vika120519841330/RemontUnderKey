using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class UnitOfJob_Infra_Domain
    {
        public static UnitOfJob_Domain UnitOfJobFromInfraToDomain(this UnitOfJob_Infra @this)
        {
            if (@this != null)
            {
                return new UnitOfJob_Domain()
                {
                    Id = @this.Id,
                    TitleOfUnit = @this.TitleOfUnit
                };
            }
            else
            {
                return null;
            }
        }
        public static UnitOfJob_Infra UnitOfJobFromDomainToInfra(this UnitOfJob_Domain @this)
        {
            if (@this != null)
            {
                return new UnitOfJob_Infra()
                {
                    Id = @this.Id,
                    TitleOfUnit = @this.TitleOfUnit
                };
            }
            else
            {
                return null;
            }
        }
    }
}
