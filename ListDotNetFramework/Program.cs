using System;
using Microsoft.Win32;

namespace ListDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Installed .NET Framework version:");
            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine(DotNetVersion());
        }

        public static string DotNetVersion()
        {
            RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full");
            if (ndpKey != null)
            {
                int value = (int)(ndpKey.GetValue("Release") ?? 0);
                if (value >= 528040)
                    return".NET Framework 4.8"; 
                if (value >= 461808) 
                    return".NET Framework 4.7.2"; 
                if (value >= 461308)
                    return".NET Framework 4.7.1"; 
                if (value >= 460798)
                    return".NET Framework 4.7"; 
                if (value >= 394802)
                    return".NET Framework 4.6.2"; 
                if (value >= 394254)
                    return".NET Framework 4.6.1"; 
                if (value >= 393295)
                    return".NET Framework 4.6"; 
                if (value >= 379893)
                    return".NET Framework 4.5.2"; 
                if (value >= 378675)
                    return".NET Framework 4.5.1"; 
                if (value >= 378389)
                    return".NET Framework 4.5";
            }
            return "No .NET Framework detected."; 
        }
    }
}

