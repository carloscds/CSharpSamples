using System;

namespace BasicDI
{
    public interface IServico
    {
        public void Executa();
    }

    public class ServicoCarro : IServico
    {
        public void Executa()
        {
            System.Console.WriteLine("Serviço executado no carro!");  
        }
    }

    public class ServicoMoto : IServico
    {
        public void Executa()
        {
            System.Console.WriteLine("Serviço executado na moto!");
        }
    }
}