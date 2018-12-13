using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

    }
}
