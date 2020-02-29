using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace ExemploILEmit
{
    class Program
    {
        static void Main(string[] args)
        {
            var tipo = CriaClasse();
            var instancia = Activator.CreateInstance(tipo, new object[0]);
            var retorno = tipo.InvokeMember("Soma", BindingFlags.InvokeMethod, null, instancia, new object[] { 2,3 });
            Console.WriteLine($"Resultado: {retorno}");
        }

        public static Type CriaClasse()
        {
            AssemblyName assemblyName = new AssemblyName("Calcular");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("ModuloCalcular");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("Calculo", TypeAttributes.Public);
            Type[] paramTypes = new[] { typeof(Int32), typeof(Int32) };
            Type returnType = typeof(Int32);
            MethodBuilder metodo = typeBuilder.DefineMethod("Soma", MethodAttributes.Public | MethodAttributes.Static, returnType, paramTypes);

            ILGenerator il = metodo.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Ret);
            var tipo = typeBuilder.CreateType();
            return tipo;
        }
    }

}
