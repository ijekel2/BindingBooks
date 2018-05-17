using System;
using System.ComponentModel.DataAnnotations;

namespace BindingBooks.Extensions
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimumValue) : base(typeof(DateTime), minimumValue, DateTime.Now.ToShortDateString())
        {
            
        }
    }
}