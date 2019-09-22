using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Web.Mappers
{
    public static class UnitOfJob_Domain_View
    {
        public static UnitOfJob_View UnitOfJobFromDomainToView(this UnitOfJob_Domain @this)
        {
            if (@this != null)
            {
                return new UnitOfJob_View()
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
        public static UnitOfJob_Domain UnitOfJobFromViewToDomain(this UnitOfJob_View @this)
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
    }
}
