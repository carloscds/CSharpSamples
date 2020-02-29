using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BasicDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var execCarro = new ExecutaServico(new ServicoCarro());
            execCarro.Executa();
            
            var execMoto = new ExecutaServico(new ServicoMoto());
            execMoto.Executa();

        }
    }

}
