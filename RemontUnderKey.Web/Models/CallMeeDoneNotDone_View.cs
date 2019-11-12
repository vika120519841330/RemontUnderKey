using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Models
{
    public class CallMeeDoneNotDone_View
    {
        public List<CallMee_View> DoneCallMee { get; set; }
        public List<CallMee_View> NotDoneCallMee { get; set; }

    }
}
