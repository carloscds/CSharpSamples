using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace StringsSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            var mem0 = GC.GetTotalMemory(false);
            string str = new String('C', 10000);
            var mem1 = GC.GetTotalMemory(false);
            ReadOnlySpan<char> strSpan = str.AsSpan();
            var mem2 = GC.GetTotalMemory(false);
            string strCarlos = str.Substring(0, 5000); // alocacao memória
            var mem3 = GC.GetTotalMemory(false);
            var spCarlos = strSpan.Slice(0, 5000); // sem alocação de memória
            //var spCarlos = str.Substring(0, 5000); // alocação memória
            var mem4 = GC.GetTotalMemory(false);
            Console.WriteLine(mem0);
            Console.WriteLine(mem1);
            Console.WriteLine(mem2);
            Console.WriteLine(mem3);
            Console.WriteLine(mem4);
        }
    }
}
