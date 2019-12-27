using System;
using System.ComponentModel.DataAnnotations;

namespace Videoclub.Restricciones
{
    public class RestrictedDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day); //Dates Greater than or equal to today are valid (true)
        }
    }
}