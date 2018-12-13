using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Northwind.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)] //gizledik
        public int ProductID { get; set; }

        [Required] //zorunlu alan
        public string ProductName { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}
