using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.EF
{
    public class ContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseSqlServer(config.GetSection("ConnectionStrings:Banco").Value);
            return new Contexto(optionsBuilder.Options);
        }
    }
}
