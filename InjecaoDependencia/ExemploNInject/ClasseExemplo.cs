using System;

namespace ExemploNInject
{
    public interface IServico
    {
        public void Executa();
    }

    public class MeuServico : IServico
    {
        public void Executa()
        {
            System.Console.WriteLine("Servico Executado!");
        }
    }
}