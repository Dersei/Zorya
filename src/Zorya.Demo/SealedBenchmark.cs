using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[InliningDiagnoser(false, new []{"Zorya.Demo"})]
public class SealedBenchmark
{
    private const int LoopIterations = 50_000;
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Class")]
    public string Variant()
    {
        PaddingVariantChildProperty v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildProperty();
            s = v.Test();
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string VariantSealed()
    {
        PaddingVariantChildPropertySealed v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildPropertySealed();
            s = v.Test();
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string Variant_Inline()
    {
        PaddingVariantChildProperty v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildProperty();
            s = v.TestInline();
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string VariantSealed_Inline()
    {
        PaddingVariantChildPropertySealed v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildPropertySealed();
            s = v.TestInline();
        }

        return s;
    }
}