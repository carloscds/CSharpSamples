using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
