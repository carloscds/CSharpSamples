using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ExemploProfiler.DTO;
using ExemploProfiler.Entidades;

namespace ExemploProfiler.Dados
{
    public class AcessoDados
    {
        private readonly SqlConnection _conexao;

        public AcessoDados()
        {
            // Baixar o banco Northwind: https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql
            _conexao = new SqlConnection("data source=(local); initial catalog=Northwind; integrated security=true; trusted_connection=true; encrypt=false;");
        }

        public List<CustomersDTO> GetClientes()
        {
            var dados = _conexao.Query<Customers>("select CustomerId, CompanyName, City from Customers");
            var dadosDTO = dados.Select(s => new CustomersDTO
            {
                Codigo = s.CustomerID,
                Nome = s.CompanyName,
                Cidade = s.City
            }).ToList();
            return dadosDTO;
        }

        public List<CustomersDTO> GetClientesPedidos()
        {
            var clientes = GetClientes();
            foreach(var c  in clientes)
            {
                var pedido = _conexao.Query<Orders>(@"select orderid,customerid, (select sum (quantity * UnitPrice) 
                                                      from [Order Details] where [Order Details].OrderID = Orders.OrderID) Total 
                                                      from orders where CustomerID = @customerID", new { customerID = c.Codigo});
                c.PedidosQtd = pedido.Count();
                c.PedidosValor = pedido.Sum(s => s.Total);
            }
            return clientes;
        }
    }
}
