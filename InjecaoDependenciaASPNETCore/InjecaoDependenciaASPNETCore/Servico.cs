using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjecaoDependenciaASPNETCore
{
    public class Servico : IServico
    {
        private int contador;
        public Servico()
        {
            contador = 0;
        }
        public string RetornaValor()
        {
            contador++;
            return $"Servico: {contador}";
        }
    }
}
