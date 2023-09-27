using BenchmarkDotNet.Attributes;
using System.Reflection;

namespace ReflectionNewWay;

public class Benchmarks
{
    private readonly Teste _teste = new Teste();

    [Benchmark]
    public void Get_Method()
    {
        var method = NovoReflector.GetMethod(_teste);
    }

    [Benchmark]
    public void Get_Field()
    {
        NovoReflector.GetField(_teste) = "Novo Field";
    }

    [Benchmark] 
    public string Get_Reflection()
    {
        return (string)_teste.GetType()
            .GetMethod("Metodo", BindingFlags.Instance | BindingFlags.NonPublic)!
            .Invoke(_teste,Array.Empty<object>())!;
    }

}
