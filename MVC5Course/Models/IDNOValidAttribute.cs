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
    }
}