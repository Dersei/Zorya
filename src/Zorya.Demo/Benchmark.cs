using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[AnyCategoriesFilter("Get","TryGet")]
[Orderer(SummaryOrderPolicy.Declared)]
[InliningDiagnoser(false, new []{nameof(Zorya.Variants), nameof(Zorya.ValueVariants)})]
public class Benchmark
{
    private const int LoopIterations = 10_000;
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Constructor")]
    public Variant4DemoNullCheck<int, string, char, byte> Variant4DemoNullCheck()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(null);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Constructor")]
    public Variant4DemoNullCheck<int, string, char, byte> Variant4DemoNullCheck_NotNull()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(1);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Constructor")]
    public Variant4DemoNullBlock<int, string, char, byte> Variant4DemoNullBlock()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(null);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Constructor")]
    public Variant4DemoNullBlock<int, string, char, byte> Variant4DemoNullBlock_NotNull()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(1);
        }

        return v;
    }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullCheck_Get()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(null);
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("TryGet")]
    public (string, bool) Variant4DemoNullCheck_TryGet()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        bool test = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(null);
            test = v.TryGet(out value);
        }

        return (value, test);
    }
    
    [Benchmark]
    [BenchmarkCategory("TryGet")]
    public (string, bool) Variant4DemoNullCheck_TryGet_NotNull()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        bool test = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>("1");
            test = v.TryGet(out value);
        }

        return (value, test);
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "TryGet")]
    public string Variant4DemoNullCheck_Get_NotNull()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>("1");
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "TryGet")]
    public string Variant4DemoNullCheck_Get_NotNull_TestItem()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>("1");
            value = v.GetWithTest<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullCheck_Get_NotNull_TypeOf()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>("1");
            value = v.GetWithTypeOf<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullCheck_Get_NotNull_TypeOf_NullCheck()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>("1");
            value = v.GetWithTypeOfNullCheck<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullBlock_Get()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(null);
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullBlock_Get_NotNull()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(1);
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("GetType")]
    public Type Variant4DemoNullCheck_GetType()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(null);
            value = v.GetSetType();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("GetType")]
    public Type Variant4DemoNullCheck_GetType_NotNull()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(1);
            value = v.GetSetType();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("GetType")]
    public Type Variant4DemoNullBlock_GetType()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(null);
            value = v.GetSetType();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("GetType")]
    public Type Variant4DemoNullBlock_GetType_NotNull()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(1);
            value = v.GetSetType();
        }

        return value;
    }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Visit")]
    public string Variant4DemoNullCheck_Visit()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string? value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(null);
            v.Visit(i1 => value = i1.ToString(), s => value = s?.ToString(), c => value = c.ToString(), b => value = b.ToString());
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Visit")]
    public string Variant4DemoNullCheck_Visit_NotNull()
    {
        Variant4DemoNullCheck<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, string, char, byte>(1);
            v.Visit(i1 => value = i1.ToString(), s => value = s?.ToString(), c => value = c.ToString(), b => value = b.ToString());

        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Visit")]
    public string Variant4DemoNullBlock_Visit()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(null);
            v.Visit(i1 => value = i1.ToString(), s => value = s?.ToString(), c => value = c.ToString(), b => value = b.ToString());

        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Visit")]
    public string Variant4DemoNullBlock_Visit_NotNull()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>(1);
            v.Visit(i1 => value = i1.ToString(), s => value = s?.ToString(), c => value = c.ToString(), b => value = b.ToString());
        }

        return value;
    }
}