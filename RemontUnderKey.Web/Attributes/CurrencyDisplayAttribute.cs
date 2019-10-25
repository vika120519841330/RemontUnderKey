using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RemontUnderKey.Web.Attributes
{
    public class CurrencyDisplayAttribute : DataTypeAttribute
    {
        public string Culture { get; set; }
        public CurrencyDisplayAttribute(string culture) : base(DataType.Currency)
        {
            Culture = culture;
        }
    }
}