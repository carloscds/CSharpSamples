using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjecaoDependenciaDiretaEF.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal LimiteCredito { get; set; }
    }
}
