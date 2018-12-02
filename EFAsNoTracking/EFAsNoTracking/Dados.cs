using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAsNoTracking
{
    public class Dados
    {
        private Contexto _contexto;
        public Dados(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Categories Get(int id) => _contexto.Categories.First(c => c.CategoryID == id);
        public Categories GetNoTracking(int id) => _contexto.Categories.AsNoTracking().First(c => c.CategoryID == id);
    }
}
