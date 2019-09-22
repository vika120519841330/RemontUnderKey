using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{
    public static class KindOfJob_Domain_View
    {
        public static KindOfJob_View KindOfJobFromDomainToView(this KindOfJob_Domain @this)
        {
            if (@this != null)
            {
                return new KindOfJob_View()
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
        public static KindOfJob_Domain KindOfJobFromViewToDomain(this KindOfJob_View @this)
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
    }
}
