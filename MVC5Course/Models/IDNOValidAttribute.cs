using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC5Course.Models
{
    public class IDNOValidAttribute : DataTypeAttribute
    {
        public IDNOValidAttribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            var str = (string)value;

            return str.Contains(" ");

            Regex _Regex = new Regex(@"^[A-Z]\d{9}");
            return value.ToString().Contains(" ");
            //return !_Regex.IsMatch(value.ToString());
        }
    }
}