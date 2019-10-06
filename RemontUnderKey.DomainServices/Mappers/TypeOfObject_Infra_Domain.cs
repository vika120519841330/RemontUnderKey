using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class TypeOfObject_Infra_Domain
    {
        public static TypeOfObject_Domain TypeOfObjectFromInfraToDomain(this TypeOfObject_Infra @this)
        {
            if (@this != null)
            {
                return new TypeOfObject_Domain()
                {
                    Id = @this.Id,
                    TitleOfTypeOfObject = @this.TitleOfTypeOfObject,
                    ImgSrc = @this.ImgSrc,
                    DescriptionOfTypeOfObject = @this.DescriptionOfTypeOfObject
                };
            }
            else
            {
                return null;
            }
        }
        public static TypeOfObject_Infra TypeOfObjectFromDomainToInfra(this TypeOfObject_Domain @this)
        {
            if (@this != null)
            {
                return new TypeOfObject_Infra()
                {
                    Id = @this.Id,
                    TitleOfTypeOfObject = @this.TitleOfTypeOfObject,
                    ImgSrc = @this.ImgSrc,
                    DescriptionOfTypeOfObject = @this.DescriptionOfTypeOfObject
                };
            }
            else
            {
                return null;
            }
        }
    }
}
