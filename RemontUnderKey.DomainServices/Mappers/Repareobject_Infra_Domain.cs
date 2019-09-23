using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class RepareobjectComment_Infra_Domain
    {
        public static Repareobject_Domain RepareobjectFromInfraToDomain(this Repareobject_Infra @this)
        {
            if (@this != null)
            {
                return new Repareobject_Domain()
                {
                    Id = @this.Id,
                    AddressOfRepareobject = @this.AddressOfRepareobject,
                    TypeOfObject_DomainId = @this.TypeOfObject_InfraId
                };
            }
            else
            {
                return null;
            }
        }
        public static Repareobject_Infra RepareobjectFromDomainToInfra(this Repareobject_Domain @this)
        {
            if (@this != null)
            {
                return new Repareobject_Infra()
                {
                    Id = @this.Id,
                    AddressOfRepareobject = @this.AddressOfRepareobject,
                    TypeOfObject_InfraId = @this.TypeOfObject_DomainId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
