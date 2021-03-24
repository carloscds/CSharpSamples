using EFLog.Dominio;
using EFLog.EF;
using System;
using System.Linq;

namespace EFLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Contexto();

            var hoje = DateTime.Now;

            var dados = db.Pedido.Where(w => w.Data == hoje).ToList();
        }
    }
}
