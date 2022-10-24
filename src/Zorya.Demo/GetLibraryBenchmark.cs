using System.Diagnostics;
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
[AnyCategoriesFilter("Get")]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[InliningDiagnoser(false, new[] {nameof(Variants), nameof(ValueVariants)})]
public class GetLibraryBenchmark
{
    private const int LoopIterations = 100;

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get", "Struct")]
    public string GetVariant_Struct()
    {
        var r = false;
        var rs = string.Empty;
        var v = new Variant<int, decimal, char, byte, object, long, string, bool>(true);

        for (var j = 0; j < LoopIterations; j++)
        {
            r = v.Get<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetVariant_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;
        var v = new Variant<int, decimal, char, byte, object, long, string, bool>("true");
        for (var j = 0; j < LoopIterations; j++)
        {
            r = v.Get<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetValueVariant_Struct()
    {
        var r = false;
        var rs = string.Empty;
        var v = new ValueVariant<int, decimal, char, byte, object, long, string, bool>(true);
        for (var j = 0; j < LoopIterations; j++)
        {
            r = v.Get<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetValueVariant_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;
        var v = new ValueVariant<int, decimal, char, byte, object, long, string, bool>("true");
        for (var j = 0; j < LoopIterations; j++)
        {
            r = v.Get<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }
}