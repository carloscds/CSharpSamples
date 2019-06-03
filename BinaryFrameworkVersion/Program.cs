//
// Get Asembly Version and Target Framework
//
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;

namespace BinaryFrameworkVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminho = ".";
            if(args.Length != 0)
            {
                caminho = args[0];
            }
            var arquivos = Directory.GetFiles(caminho);
            foreach(var arq in arquivos)
            {
                var ext = Path.GetExtension(arq).ToUpper();
                if(ext == ".DLL" || ext == ".EXE")
                {
                    var arqName = new FileInfo(arq);
                    var version = "";
                    var target = "";
                    try
                    {
                        Assembly asm = Assembly.LoadFile(arqName.FullName);
                        version = asm.GetName().Version.ToString();
                        target = asm.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
                    }
                    catch
                    {
                        target = "Nao identificado";
                    }
                    Console.WriteLine($"{Path.GetFileName(arqName.FullName)} - {version} - {target}");
                }
            }
        }
    }
}
