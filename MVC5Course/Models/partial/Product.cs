using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public partial class Product
    {
        public string PriceFormat
        {
            get
            {
                return string.Format("{0:C}", Price);
            }
        }
    }
}