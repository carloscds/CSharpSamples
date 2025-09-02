using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int? ClienteId { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }

        public Pedido()
        {
            PedidoItem = new List<PedidoItem>();
        }
    }
}
