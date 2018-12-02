using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAsNoTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Contexto();

            var dados1 = new Dados(db);
            var cat = dados1.GetNoTracking(1);
            Console.WriteLine(cat.CategoryName);

            var dados2 = new Dados(db);
            var cat2 = dados2.Get(2);
            cat2.CategoryName += " 2";

            var tracker = db.ChangeTracker.Entries();
            foreach(var t in tracker)
            {
                Console.WriteLine($"{t.Entity.ToString()}, {t.State}");
            }

        }
    }
}
