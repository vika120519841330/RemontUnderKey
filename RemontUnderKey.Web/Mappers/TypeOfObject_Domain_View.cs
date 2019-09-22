using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{
    public static class TypeOfObject_Domain_View
    {
        public static TypeOfObject_View TypeOfObjectFromDomainToView(this TypeOfObject_Domain @this)
        {
            if (@this != null)
            {
                return new TypeOfObject_View()
                {
                    Id = @this.Id,
                    TitleOfTypeOfObject = @this.TitleOfTypeOfObject,
                    DescriptionOfTypeOfObject = @this.DescriptionOfTypeOfObject
                };
            }
            else
            {
                return null;
            }
        }
        public static TypeOfObject_Domain TypeOfObjectFromViewToDomain(this TypeOfObject_View @this)
        {
            if (@this != null)
            {
                return new TypeOfObject_Domain()
                {
                    Id = @this.Id,
                    TitleOfTypeOfObject = @this.TitleOfTypeOfObject,
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
