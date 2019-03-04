using System;

namespace NetworkCardInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var card = new NetworkCardUtil();

            var info = card.ConfiguracaoRede();
            System.Console.WriteLine(info);
        }
    }
}
