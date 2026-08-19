using MCPExemplo.Domain;

namespace MCPExemplo.Dados
{
    public static class BaseDados
    {
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Produto> Produtos = new List<Produto>();
        public static List<Pedido> Pedidos = new List<Pedido>();

        public static void Seed()
        {
            Clientes.Clear();
            Produtos.Clear();
            Pedidos.Clear();

            // Clientes
            Clientes.Add(new Cliente { Id = 1, Nome = "João Silva" });
            Clientes.Add(new Cliente { Id = 2, Nome = "Maria Souza" });
            Clientes.Add(new Cliente { Id = 3, Nome = "Empresa XYZ" });

            // Produtos
            Produtos.Add(new Produto { Id = 1, Nome = "Caneta", Valor = 2.50m });
            Produtos.Add(new Produto { Id = 2, Nome = "Caderno", Valor = 15.00m });
            Produtos.Add(new Produto { Id = 3, Nome = "Mochila", Valor = 120.00m });
            Produtos.Add(new Produto { Id = 4, Nome = "Livro - C# Avançado", Valor = 75.90m });

            // Pedidos
            var pedido1 = new Pedido
            {
                Id = 1,
                ClienteId = 1,
                Data = DateTime.Now.AddDays(-5),
            };
            pedido1.Items.Add(new PedidoItem { PedidoId = pedido1.Id, ProdutoId = 1, Quantidade = 10, Valor = Produtos.Find(p => p.Id == 1)!.Valor });
            pedido1.Items.Add(new PedidoItem { PedidoId = pedido1.Id, ProdutoId = 2, Quantidade = 2, Valor = Produtos.Find(p => p.Id == 2)!.Valor });
            pedido1.Valor = CalculaTotalPedido(pedido1);

            var pedido2 = new Pedido
            {
                Id = 2,
                ClienteId = 2,
                Data = DateTime.Now.AddDays(-1),
            };
            pedido2.Items.Add(new PedidoItem { PedidoId = pedido2.Id, ProdutoId = 3, Quantidade = 1, Valor = Produtos.Find(p => p.Id == 3)!.Valor });
            pedido2.Items.Add(new PedidoItem { PedidoId = pedido2.Id, ProdutoId = 4, Quantidade = 1, Valor = Produtos.Find(p => p.Id == 4)!.Valor });
            pedido2.Valor = CalculaTotalPedido(pedido2);

            var pedido3 = new Pedido
            {
                Id = 3,
                ClienteId = 2,
                Data = DateTime.Now.AddDays(-1),
            };
            pedido3.Items.Add(new PedidoItem { PedidoId = pedido3.Id, ProdutoId = 3, Quantidade = 1, Valor = Produtos.Find(p => p.Id == 3)!.Valor });
            pedido3.Items.Add(new PedidoItem { PedidoId = pedido3.Id, ProdutoId = 4, Quantidade = 1, Valor = Produtos.Find(p => p.Id == 4)!.Valor });
            pedido3.Valor = CalculaTotalPedido(pedido3);

            Pedidos.Add(pedido1);
            Pedidos.Add(pedido2);
            Pedidos.Add(pedido3);
        }

        public static decimal CalculaTotalPedido(Pedido pedido)
        {
            decimal total = 0m;
            foreach (var item in pedido.Items)
            {
                total += item.Valor * item.Quantidade;
            }
            return total;
        }

        public static void Delete()
        {
            Clientes.Clear();
            Produtos.Clear();
            Pedidos.Clear();
        }
    }
}
