using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;
using Zorya.ValueVariants;
using Zorya.Variants;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.Declared)]
[InliningDiagnoser(false, new []{nameof(Zorya.Variants), nameof(Zorya.ValueVariants)})]
public class MemoryBenchmark
{
    private const int LoopIterations = 10_000;
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Class")]
    public Variant<int, string, char> Variant3()
    {
        Variant<int, string, char> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant<int, string, char>(1);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public Variant<int, string, char, byte> Variant4()
    {
        Variant<int, string, char, byte> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant<int, string, char, byte>(1);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public Variant<int, string, char, byte, long, double, object, decimal> Variant8()
    {
        Variant<int, string, char, byte, long, double, object, decimal> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant<int, string, char, byte, long, double, object, decimal>(1);
        }

        return v;
    }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Struct")]
    public ValueVariant<int, string, char> ValueVariant3()
    {
        ValueVariant<int, string, char> v = new();

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new ValueVariant<int, string, char>(1);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Struct")]
    public ValueVariant<int, string, char, byte> ValueVariant4()
    {
        ValueVariant<int, string, char, byte> v = new();

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new ValueVariant<int, string, char, byte>(1);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Struct")]
    public ValueVariant<int, string, char, byte, long, double, object, decimal> ValueVariant8()
    {
        ValueVariant<int, string, char, byte, long, double, object, decimal> v = new();

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new ValueVariant<int, string, char, byte, long, double, object, decimal>(1);
        }

        return v;
    }
}