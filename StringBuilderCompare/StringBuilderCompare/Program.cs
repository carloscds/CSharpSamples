using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            int iteracao = 5000;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string texto = "";
            for(int i=0;i<iteracao;i++)
            {
                texto += i.ToString() + " ";
            }
            sw.Stop();
            Console.WriteLine($"string concat {iteracao} iterações: {sw.ElapsedMilliseconds} ms");
            sw.Reset();

            sw.Start();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iteracao; i++)
            {
                sb.Append(i.ToString() + " ");
            }
            var texto1 = sb.ToString();
            sw.Stop();
            Console.WriteLine($"StringBuilder {iteracao} iterações: {sw.ElapsedMilliseconds} ms");
        }
    }
}
