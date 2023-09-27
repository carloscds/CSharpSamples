using BenchmarkDotNet.Running;
using ReflectionNewWay;
using System.Runtime.CompilerServices;

BenchmarkRunner.Run<Benchmarks>();
return;

var teste = new Teste();
var method = NovoReflector.GetMethod(teste);
NovoReflector.GetField(teste) = "Novo Field";
Console.WriteLine(teste);


public class NovoReflector
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Metodo")]
    public static extern string GetMethod(Teste teste);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "Campo")]
    public static extern ref string GetField(Teste teste);
}

public class Teste
{
    private string Campo = "Campo";
    private string Metodo() => "Carlos";
}