using System;

namespace BasicDI
{
    public class ExecutaServico
    {
        private IServico _servico;
        public ExecutaServico(IServico servico)
        {
            _servico = servico;
        }

        public void Executa()
        {
            _servico.Executa();
        }
    }
}