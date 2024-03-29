﻿using System;
using System.IO;
using System.Linq;
using EFCoreSample.EF;
using EFCoreSample.MigrationsFactory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextFactory = new ContextFactory();
            var db = contextFactory.CreateDbContext(null);

            var produtos  = db.Produto.Where(p => p.GrupoId == 1)
                     .Select(s => new {Id = s.Id, Nome = s.Nome});

            var produtosGrupos = db.Produto.Where(p => p.GrupoId == 1)
                    .Select(s => new { Id = s.Id, Nome = s.Nome, Grupo = s.Grupo.Nome });

            //  foreach(var p in produtos)
            //  {
            //      System.Console.WriteLine($"{p.Id} - {p.Nome}");
            //  }
            //var contemNome = db.Produto.Where(w => w.Nome.StartsWith("3"))
            //.ToList();
            var nome = db.Produto.First(w => w.Nome == "Produto 3");
        }


        static Contexto ConfigDB()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var builder = new DbContextOptionsBuilder<Contexto>()
                    .UseSqlServer(configuration.GetConnectionString("BancoSQL"))
                    .UseLoggerFactory(LoggerFactory.Create((builder => builder.AddConsole()))
                    );
            return new Contexto(builder.Options);
        }
    }
}
