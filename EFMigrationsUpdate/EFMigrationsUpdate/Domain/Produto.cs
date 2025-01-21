using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMigrationsUpdate.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public Guid Key { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Custo { get; set; }
    }
}
