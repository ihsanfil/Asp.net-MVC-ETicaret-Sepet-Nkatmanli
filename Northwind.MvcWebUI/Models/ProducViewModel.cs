using System.Collections.Generic;
using Northwind.Entities;

namespace Northwind.MvcWebUI.Models
{
    public class ProducViewModel
    {
        public List<Product> Products { get; set; }
        public PageingInfo PageingInfo { get; set; }
    }
}