using System;

namespace ExemploRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int i in num[1..5])
            {
                Console.Write(i);
            }
            Console.WriteLine("");

            string str = "Exemplo em C# 8";

            foreach (var s in str[^4..^0])
            {
                Console.Write(s);
            }
            Console.WriteLine("");
        }
    }
}
