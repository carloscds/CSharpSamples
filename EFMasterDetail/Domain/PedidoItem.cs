using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.Domain
{
    public class PedidoItem
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }


    }
}
