using System;
using Ninject;

namespace ExemploNInject
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninject.IKernel inject = new StandardKernel();  
            inject.Bind<IServico>().To<MeuServico>();  
            var obj = inject.Get<ExecutaDI>();  
            obj.Executa();   
        }
    }
}
