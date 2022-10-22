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
public class GetBenchmark
{
    private const int LoopIterations = 10_000;
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetStandard()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetStandard<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetStandard_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetStandard<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetStandard_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetStandard<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetStandard_Inline()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetStandardInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetStandard_Inline_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetStandardInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetStandard_Inline_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetStandardInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafe()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafe<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafe_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafe<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafe_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetUnsafe<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafe_Inline()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafeInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafe_Inline_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafeInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafe_Inline_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetUnsafeInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
     [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafeNullCheck()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafeNullCheck<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafeNullCheck_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafeNullCheck<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeNullCheck_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetUnsafeNullCheck<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetUnsafeNullCheck_Inline()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafeNullCheckInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetUnsafeNullCheck_Inline_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetUnsafeNullCheckInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    //[Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeNullCheck_Inline_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetUnsafeNullCheckInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    //      [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string GetTestItem()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
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
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
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
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
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
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
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
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
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
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
    //         value = v.GetTestItemInline<string>();
    //     }
    //     Trace.Assert(value == "true");
    //     return value;
    // }
  //   
  //     [Benchmark]
  //   [BenchmarkCategory("Get", "HasStructGetClass")]
  //   public string GetIf()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetIf<string>();
  //       }
  //       Trace.Assert(value == null);
  //       return value;
  //   }
  //   
  //   [Benchmark]
  //   [BenchmarkCategory("Get", "Struct")]
  //   public bool GetIf_Struct()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       bool value = false;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetIf<bool>();
  //       }
  //       Trace.Assert(value);
  //       return value;
  //   }
  //   
  //   [Benchmark]
  //   [BenchmarkCategory("Get", "Class")]
  //   public string GetIf_Class()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
  //           value = v.GetIf<string>();
  //       }
  //       Trace.Assert(value == "true");
  //       return value;
  //   }
  //   
  //   //[Benchmark]
  //   [BenchmarkCategory("Get", "HasStructGetClass")]
  //   public string GetIf_Inline()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetIfInline<string>();
  //       }
  //       Trace.Assert(value == null);
  //       return value;
  //   }
  //   
  //  // [Benchmark]
  //   [BenchmarkCategory("Get", "Struct")]
  //   public bool GGetIf_Inline_Struct()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       bool value = false;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetIfInline<bool>();
  //       }
  //       Trace.Assert(value);
  //       return value;
  //   }
  //   
  // //  [Benchmark]
  //   [BenchmarkCategory("Get", "Class")]
  //   public string GetIf_Inline_Class()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
  //           value = v.GetIfInline<string>();
  //       }
  //       Trace.Assert(value == "true");
  //       return value;
  //   }
    
        [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetDoubleCheck()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetDoubleCheck<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetDoubleCheck_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetDoubleCheck<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetDoubleCheck_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetDoubleCheck<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
   // [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string GetDoubleCheck_Inline()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetDoubleCheckInline<string>();
        }
        Trace.Assert(value == null);
        return value;
    }
    
 //   [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool GetDoubleCheck_Inline_Struct()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            value = v.GetDoubleCheckInline<bool>();
        }
        Trace.Assert(value);
        return value;
    }
    
//    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetDoubleCheck_Inline_Class()
    {
        Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            value = v.GetDoubleCheckInline<string>();
        }
        Trace.Assert(value == "true");
        return value;
    }
    
    // //
    //
    //         [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string GetUnsafeCastResult()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
    //         value = v.GetUnsafeCastResult<string>();
    //     }
    //     Trace.Assert(value == null);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Struct")]
    // public bool GetUnsafeCastResult_Struct()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
    //         value = v.GetUnsafeCastResult<bool>();
    //     }
    //     Trace.Assert(value);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Class")]
    // public string GetUnsafeCastResult_Class()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
    //         value = v.GetUnsafeCastResult<string>();
    //     }
    //     Trace.Assert(value == "true");
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string GetUnsafeCastResult_Inline()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
    //         value = v.GetUnsafeCastResultInline<string>();
    //     }
    //     Trace.Assert(value == null);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Struct")]
    // public bool GetUnsafeCastResult_Inline_Struct()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
    //         value = v.GetUnsafeCastResultInline<bool>();
    //     }
    //     Trace.Assert(value);
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Class")]
    // public string GetUnsafeCastResult_Inline_Class()
    // {
    //     Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
    //         value = v.GetUnsafeCastResultInline<string>();
    //     }
    //     Trace.Assert(value == "true");
    //     return value;
    // }
    
  //       [Benchmark]
  //   [BenchmarkCategory("Get", "HasStructGetClass")]
  //   public string GetTripleCheck()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetTripleCheck<string>();
  //       }
  //       Trace.Assert(value == null);
  //       return value;
  //   }
  //   
  //   [Benchmark]
  //   [BenchmarkCategory("Get", "Struct")]
  //   public bool GetTripleCheck_Struct()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       bool value = false;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetTripleCheck<bool>();
  //       }
  //       Trace.Assert(value);
  //       return value;
  //   }
  //   
  //   [Benchmark]
  //   [BenchmarkCategory("Get", "Class")]
  //   public string GetTripleCheck_Class()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
  //           value = v.GetTripleCheck<string>();
  //       }
  //       Trace.Assert(value == "true");
  //       return value;
  //   }
  //   
  // //  [Benchmark]
  //   [BenchmarkCategory("Get", "HasStructGetClass")]
  //   public string GetTripleCheck_Inline()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetTripleCheckInline<string>();
  //       }
  //       Trace.Assert(value == null);
  //       return value;
  //   }
  //   
  // //  [Benchmark]
  //   [BenchmarkCategory("Get", "Struct")]
  //   public bool GetTripleCheck_Inline_Struct()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       bool value = false;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
  //           value = v.GetTripleCheckInline<bool>();
  //       }
  //       Trace.Assert(value);
  //       return value;
  //   }
  //   
  // //  [Benchmark]
  //   [BenchmarkCategory("Get", "Class")]
  //   public string GetTripleCheck_Inline_Class()
  //   {
  //       Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
  //       string value = null;
  //       for (int i = 0; i < LoopIterations; i++)
  //       {
  //           v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
  //           value = v.GetTripleCheckInline<string>();
  //       }
  //       Trace.Assert(value == "true");
  //       return value;
  //   }
    
}