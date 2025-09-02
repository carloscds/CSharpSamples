using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pedido>? Pedido { get; set; }
    }
}
