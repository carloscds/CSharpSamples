using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjecaoDependenciaASPNETCore
{
    public class ExecutaServico
    {
        private readonly IServico _servico;
        public ExecutaServico(IServico servico)
        {
            _servico = servico;
        }

        public string RetornaServicoExecutado() => _servico.RetornaValor();
    }
}
