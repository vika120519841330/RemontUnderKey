using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;


namespace RemontUnderKey.DomainServices.Mappers
{
    public static class CallMee_Infra_Domain
    {
        public static CallMee_Domain CallMeeFromInfraToDomain(this CallMee_Infra @this)
        {
            if (@this != null)
            {
                return new CallMee_Domain()
                {
                    Id = @this.Id,
                    Name = @this.Name,
                    Telephone = @this.Telephone,
                    DateStamp = @this.DateStamp,
                    Wishes = @this.Wishes
                };
            }
            else
            {
                return null;
            }
        }
        public static CallMee_Infra CallMeeFromDomainToInfra(this CallMee_Domain @this)
        {
            if (@this != null)
            {
                return new CallMee_Infra()
                {
                    Id = @this.Id,
                    Name = @this.Name,
                    Telephone = @this.Telephone,
                    DateStamp = @this.DateStamp,
                    Wishes = @this.Wishes
                };
            }
            else
            {
                return null;
            }
        }
    }
}
