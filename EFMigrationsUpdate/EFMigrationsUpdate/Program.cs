using EFMigrationsUpdate.Data.EF;
using EFMigrationsUpdate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFMigrationsUpdate
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ContextFactory();
            var db = factory.CreateDbContext(null);

            var pro = new Produto
            {
                Nome = "Produto " + DateTime.Now.ToString()
            };
            db.Produto.Add(pro);
            db.SaveChanges();
        }
    }
}
