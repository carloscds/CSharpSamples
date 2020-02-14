using System;

namespace ExemploNInject
{
    public class ExecutaDI 
    {
        private IServico _servico;
        public ExecutaDI(IServico servico)
        {
            _servico = servico;
        }
        public void Executa()
        {
            _servico.Executa();
        }
    }
}