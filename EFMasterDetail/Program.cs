using EFMasterDetail.Domain;
using EFMasterDetail.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace EFMasterDetail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder
                .UseSqlServer(config.GetSection("ConnectionStrings:Banco").Value)
                .UseLazyLoadingProxies();

            var db = new Contexto(optionsBuilder.Options);

            //var cli = new Cliente { Nome = "Manoel" };
            //db.Cliente.Add(cli);
            //var pro = new Produto { Nome = "Impressora", Valor = 200M };
            //db.Produto.Add(pro);

            ////var cli = db.Cliente.First();
            ////var pro = db.Produto.First();


            //var pedido = new Pedido
            //{
            //    Data = DateTime.Now,
            //    Cliente = cli,
            //    PedidoItem = new List<PedidoItem>() {
            //        new PedidoItem { Produto = pro, Quantidade = 1, Valor = 200M}
            //    },
            //    Total = 200M

            //};
            //db.Pedido.Add(pedido);
            //db.SaveChanges();

            var pedidos = db.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.PedidoItem)
                    .ThenInclude(pi => pi.Produto);

            foreach (var p in pedidos)
            {
                Console.WriteLine($"Pedido: {p.Id} - Data: {p.Data} - Valor: {p.Total} - Cliente: {p.Cliente.Nome}");
                foreach(var pi in p.PedidoItem) 
                {
                    Console.WriteLine($"\t{pi.Produto.Nome} - {pi.Quantidade} - {pi.Valor}");
                }
                Console.WriteLine("---");
            }
            var clientes = db.Cliente.OrderBy(o => o.Nome);
            Console.WriteLine("Pedidos por Cliente:");
            foreach(var c in clientes)
            {
                Console.WriteLine($"{c.Nome} - {c.Pedido.Count} - Total: {c.Pedido.Sum(p => p.Total)}");
            }
        }
    }
}