using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Web.Mappers
{
    public static class CallMee_Domain_View
    {
        public static CallMee_View CallMeeFromDomainToView(this CallMee_Domain @this)
        {
            if (@this != null)
            {
                return new CallMee_View()
                {
                    Id = @this.Id,
                    Name = @this.Name,
                    Telephone = @this.Telephone,
                    DateStamp = @this.DateStamp,
                    Comments = @this.Comments,
                    CallIsDone = @this.CallIsDone
                };
            }
            else
            {
                return null;
            }
        }
        public static CallMee_Domain CallMeeFromViewToDomain(this CallMee_View @this)
        {
            if (@this != null)
            {
                return new CallMee_Domain()
                {
                    Id = @this.Id,
                    Name = @this.Name,
                    Telephone = @this.Telephone,
                    DateStamp = @this.DateStamp,
                    Comments = @this.Comments,
                    CallIsDone = @this.CallIsDone
                };
            }
            else
            {
                return null;
            }
        }
    }
}
