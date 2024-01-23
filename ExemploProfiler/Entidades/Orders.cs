using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploProfiler.Entidades
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public decimal Total { get; set; }
    }
}
