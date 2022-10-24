using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[AnyCategoriesFilter("Get")]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[InliningDiagnoser(false, new []{nameof(Variants), nameof(ValueVariants)})]
public class Get4Benchmark
{
    private const int LoopIterations = 10_000;
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetStandard()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetStandard<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetStandard_Struct()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetStandard<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetStandard_Class()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>("true");
            value = v.GetStandard<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetStandard_Inline()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetStandardInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetStandard_Inline_Struct()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetStandardInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetStandard_Inline_Class()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>("true");
            value = v.GetStandardInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafe()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafe<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafe_Struct()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafe<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafe_Class()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>("true");
            value = v.GetUnsafe<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafe_Inline()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafeInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafe_Inline_Struct()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafeInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafe_Inline_Class()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>("true");
            value = v.GetUnsafeInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
     [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafeNullCheck()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafeNullCheck<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafeNullCheck_Struct()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafeNullCheck<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeNullCheck_Class()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>("true");
            value = v.GetUnsafeNullCheck<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafeNullCheck_Inline()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafeNullCheckInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafeNullCheck_Inline_Struct()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>(true);
            value = v.GetUnsafeNullCheckInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeNullCheck_Inline_Class()
    {
        Variant4Demo<int, decimal, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant4Demo<int, decimal, string, bool>("true");
            value = v.GetUnsafeNullCheckInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    //      [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string GetTestItem()
    // {
    //     Variant4Demo<int, decimal, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant4Demo<int, decimal, string, bool>(true);
    //         value = v.GetTestItem<string>();
    //     }
    //     Trace.Assert(value == null);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Struct")]
    // public bool GetTestItem_Struct()
    // {
    //     Variant4Demo<int, decimal, string, bool> v = null;
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant4Demo<int, decimal, string, bool>(true);
    //         value = v.GetTestItem<bool>();
    //     }
    //     Trace.Assert(value);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Class")]
    // public string GetTestItem_Class()
    // {
    //     Variant4Demo<int, decimal, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant4Demo<int, decimal, string, bool>("true");
    //         value = v.GetTestItem<string>();
    //     }
    //     Trace.Assert(value == "true");
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string GetTestItem_Inline()
    // {
    //     Variant4Demo<int, decimal, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant4Demo<int, decimal, string, bool>(true);
    //         value = v.GetTestItemInline<string>();
    //     }
    //     Trace.Assert(value == null);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Struct")]
    // public bool GetTestItem_Inline_Struct()
    // {
    //     Variant4Demo<int, decimal, string, bool> v = null;
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant4Demo<int, decimal, string, bool>(true);
    //         value = v.GetTestItemInline<bool>();
    //     }
    //     Trace.Assert(value);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Class")]
    // public string GetTestItem_Inline_Class()
    // {
    //     Variant4Demo<int, decimal, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant4Demo<int, decimal, string, bool>("true");
    //         value = v.GetTestItemInline<string>();
    //     }
    //     Trace.Assert(value == "true");
    //     return value;
    // }
}