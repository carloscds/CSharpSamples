using EFInterception.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInterception
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindContext();

            foreach(var p in db.Products)
            {
                Console.WriteLine(p.Category.CategoryName+", "+p.ProductName);
            }

            var altera = db.Products.Where(p => p.ProductID == 1).FirstOrDefault();
            if(altera != null)
            {
                altera.UnitPrice = 10;
                db.SaveChanges();
            }
        }
    }
}
