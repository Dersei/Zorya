using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
//[InliningDiagnoser(false, new[] { nameof(Variants), nameof(ValueVariants) })]
public class InheritancePaddingBenchmark
{
    private const int LoopIterations = 10_000;
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Class")]
    public string PaddingVariantChildField()
    {
        PaddingVariantChildField v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildField();
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string PaddingVariantChildProperty()
    {
        PaddingVariantChildProperty v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildProperty();
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string PaddingVariantChildPropertySealed()
    {
        PaddingVariantChildPropertySealed v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildPropertySealed();
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string PaddingVariantChildPropertySealedOnly()
    {
        PaddingVariantChildPropertySealedOnly v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildPropertySealedOnly();
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string PaddingVariantChildMethodSealed()
    {
        PaddingVariantChildMethodSealed v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildMethodSealed();
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
        }

        return s;
    }
    
    [Benchmark]
    [BenchmarkCategory("Class")]
    public string PaddingVariantChildMethod()
    {
        PaddingVariantChildMethod v = null;
        string s = string.Empty;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new PaddingVariantChildMethod();
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
            s = v.GetSetItem();
            Trace.Assert(s != null);
        }

        return s;
    }
}