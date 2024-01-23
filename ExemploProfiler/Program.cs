using ExemploProfiler.Dados;
using ExemploProfiler.DTO;
using System.Text.Json;

namespace ExemploProfiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var acessoDados = new AcessoDados();
            var clientes = acessoDados.GetClientes();
            var clientesPedidos = acessoDados.GetClientesPedidos();

            var jsonclientesPedidos = JsonSerializer.Serialize(clientesPedidos);
            Console.WriteLine(jsonclientesPedidos);

            var clientesPedidosObj = JsonSerializer.Deserialize<List<CustomersDTO>>(jsonclientesPedidos);
            foreach(var c in clientesPedidosObj)
            {
                Console.WriteLine($"{c.Nome} - {c.Cidade} - {c.PedidosValor}");
            }
        }
    }
}
