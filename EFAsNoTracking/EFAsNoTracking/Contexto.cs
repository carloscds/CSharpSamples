using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAsNoTracking
{
    public class Contexto : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

    }
}
