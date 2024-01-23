using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploProfiler.DTO
{
    public class CustomersDTO
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int PedidosQtd { get; set; }
        public decimal PedidosValor {  get; set; }
    }
}
