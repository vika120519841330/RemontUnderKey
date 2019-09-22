using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{ 
    public static class Job_Domain_View
    {
        public static Job_View JobFromDomainToView(this Job_Domain @this)
        {
            if (@this != null)
            {
                return new Job_View()
                {
                    Id = @this.Id,
                    TitleOfJob = @this.TitleOfJob,
                    PriceOfUnitOfJob = @this.PriceOfUnitOfJob,
                    KindOfJob_ViewId = @this.KindOfJob_DomainId,
                    UnitOfJob_ViewId = @this.UnitOfJob_DomainId
                };
            }
            else
            {
                return null;
            }
        }
        public static Job_Domain JobFromViewToDomain(this Job_View @this)
        {
            if (@this != null)
            {
                return new Job_Domain()
                {
                    Id = @this.Id,
                    TitleOfJob = @this.TitleOfJob,
                    PriceOfUnitOfJob = @this.PriceOfUnitOfJob,
                    KindOfJob_DomainId = @this.KindOfJob_ViewId,
                    UnitOfJob_DomainId = @this.UnitOfJob_ViewId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
