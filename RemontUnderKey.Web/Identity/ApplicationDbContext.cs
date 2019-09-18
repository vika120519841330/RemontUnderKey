using Microsoft.AspNet.Identity.EntityFramework;
using RemontUnderKey.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemontUnderKey.Web.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IdentityConnection", throwIfV1Schema: false)
        {

        }
    }
}