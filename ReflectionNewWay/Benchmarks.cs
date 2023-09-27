using BenchmarkDotNet.Attributes;

namespace ReflectionNewWay;

public class Benchmarks
{
    private readonly Teste _teste = new Teste();

    [Benchmark]
    public void Get_Method()
    {
        NovoReflector.GetMethod(_teste);
    }

    [Benchmark]
    public void Get_Field()
    {
        NovoReflector.GetField(_teste) = "Novo Field";
    }

}
