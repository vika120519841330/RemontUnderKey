using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Web.Mappers
{
    public static class RepareobjectComment_Domain_View
    {
        public static Repareobject_View RepareobjectFromDomainToView(this Repareobject_Domain @this)
        {
            if (@this != null)
            {
                return new Repareobject_View()
                {
                    Id = @this.Id,
                    AddressOfRepareobject = @this.AddressOfRepareobject,
                    TypeOfObject_ViewId = @this.TypeOfObject_DomainId
                };
            }
            else
            {
                return null;
            }
        }
        public static Repareobject_Domain RepareobjectFromViewToDomain(this Repareobject_View @this)
        {
            if (@this != null)
            {
                return new Repareobject_Domain()
                {
                    Id = @this.Id,
                    AddressOfRepareobject = @this.AddressOfRepareobject,
                    TypeOfObject_DomainId = @this.TypeOfObject_ViewId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
