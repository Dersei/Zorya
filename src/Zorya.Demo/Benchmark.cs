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
    #region Constructor
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Constructor")]
    public Variant4DemoNullCheck<int, char, string, bool> Variant4DemoNullCheck()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(null);
        }

        return v;
    }
    
    [Benchmark]
    [BenchmarkCategory("Constructor")]
    public Variant4DemoNullCheck<int, char, string, bool> Variant4DemoNullCheck_NotNull()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
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
    public Variant4DemoNullBlock<int, string, char, bool> Variant4DemoNullBlock_NotNull()
    {
        Variant4DemoNullBlock<int, string, char, bool> v = null;

        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, bool>(true);
        }

        return v;
    }
    #endregion
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullCheck_Get()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(null);
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("TryGet")]
    public (string, bool) Variant4DemoNullCheck_TryGet()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        bool test = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(null);
            test = v.TryGet(out value);
        }

        return (value, test);
    }
    
    [Benchmark]
    [BenchmarkCategory("TryGet", "Struct")]
    public (string, bool) Variant4DemoNullCheck_TryGet_NotNull_Struct()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        bool test = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            test = v.TryGet(out value);
        }

        return (value, test);
    }
    
    [Benchmark]
    [BenchmarkCategory("TryGet", "Struct")]
    public (int, bool) Variant4DemoNullCheck_TryGet_NotNull_Struct_CheckForStruct()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        int value = 0;
        bool test = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            test = v.TryGet(out value);
        }

        return (value, test);
    }
    
    [Benchmark]
    [BenchmarkCategory("TryGet", "Class")]
    public (string, bool) Variant4DemoNullCheck_TryGet_NotNull()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        bool test = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>("1");
            test = v.TryGet(out value);
        }

        return (value, test);
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string Variant4DemoNullCheck_Get_NotNull_Struct()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public int Variant4DemoNullCheck_Get_NotNull_Struct_CheckForStruct()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        int value = 0;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            value = v.Get<int>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string Variant4DemoNullCheck_Get_NotNull()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>("1");
            value = v.Get<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "TryGet", "Struct")]
    public string Variant4DemoNullCheck_Get_NotNull_Struct_TestItem()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            value = v.GetWithTest<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "TryGet", "Struct")]
    public int Variant4DemoNullCheck_Get_NotNull_Struct_CheckForStruct_TestItem()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        int value = 0;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            value = v.GetWithTest<int>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "TryGet", "Class")]
    public string Variant4DemoNullCheck_Get_NotNull_TestItem()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>("1");
            value = v.GetWithTest<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string Variant4DemoNullCheck_Get_NotNull_Struct_TypeOf()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            value = v.GetWithTypeOf<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullCheck_Get_NotNull_TypeOf()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>("1");
            value = v.GetWithTypeOf<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string Variant4DemoNullCheck_Get_NotNull_Struct_TypeOf_NullCheck()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            value = v.GetWithTypeOfNullCheck<string>();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullCheck_Get_NotNull_TypeOf_NullCheck()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>("1");
            value = v.GetWithTypeOfNullCheck<string>();
        }

        return value;
    }
    
    //[Benchmark]
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
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string Variant4DemoNullBlock_Get_NotNull_Struct()
    {
        Variant4DemoNullBlock<int, string, char, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, bool>(true);
            value = v.Get<string>();
        }

        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get")]
    public string Variant4DemoNullBlock_Get_NotNull()
    {
        Variant4DemoNullBlock<int, string, char, byte> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, byte>("1");
            value = v.Get<string>();
        }

        return value;
    }
    
    #region GetType
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("GetType")]
    public Type Variant4DemoNullCheck_GetType()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(null);
            value = v.GetSetType();
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("GetType")]
    public Type Variant4DemoNullCheck_GetType_NotNull()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
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
        Variant4DemoNullBlock<int, string, char, bool> v = null;
        Type value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, bool>(true);
            value = v.GetSetType();
        }

        return value;
    }
    
    #endregion
    
    #region Visit
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Visit")]
    public string Variant4DemoNullCheck_Visit()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string? value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(null);
            v.Visit(i1 => value = i1.ToString(), s => value = s.ToString(), c => value = c?.ToString(), b => value = b.ToString());
        }

        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Visit")]
    public string Variant4DemoNullCheck_Visit_NotNull()
    {
        Variant4DemoNullCheck<int, char, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullCheck<int, char, string, bool>(true);
            v.Visit(i1 => value = i1.ToString(), s => value = s.ToString(), c => value = c?.ToString(), b => value = b.ToString());

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
        Variant4DemoNullBlock<int, string, char, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4DemoNullBlock<int, string, char, bool>(true);
            v.Visit(i1 => value = i1.ToString(), s => value = s?.ToString(), c => value = c.ToString(), b => value = b.ToString());
        }

        return value;
    }

    #endregion
}