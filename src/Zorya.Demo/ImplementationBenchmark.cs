using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ImplementationBenchmark
{
    private const int LoopIterations = 100;
    
    // [Benchmark(Baseline = true)]
    // [BenchmarkCategory("Constructor")]
    // public ImplVariantClassic<int, decimal, char, byte, object, long, string, bool> ImplClassic_Constructor()
    // {
    //     ImplVariantClassic<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantClassic<int, decimal, char, byte, object, long, string, bool>(true);
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         v = new ImplVariantClassic<int, decimal, char, byte, object, long, string, bool>(i%2);
    //     }
    //     return v;
    // }
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string ImplClassic_HasStructGetClass()
    {
        ImplVariantClassic<int, decimal, char, byte, object, long, string, bool> v = null;
        v = new ImplVariantClassic<int, decimal, char, byte, object, long, string, bool>(true);
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            
            value = v.Get<string>();
        }
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool ImplClassic_Struct()
    {
        ImplVariantClassic<int, decimal, char, byte, object, long, string, bool> v = null;
        v = new ImplVariantClassic<int, decimal, char, byte, object, long, string, bool>(true);
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            
            value = v.Get<bool>();
        }
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string ImplClassic_Class()
    {
        ImplVariantClassic<int, decimal, char, byte, object, long, string, bool> v = null;
        v = new ImplVariantClassic<int, decimal, char, byte, object, long, string, bool>("true");
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
            
            value = v.Get<string>();
        }
        return value;
    }
    
    // [Benchmark]
    // [BenchmarkCategory("Visit")]
    // public string ImplClassic_Visit()
    // {
    //     ImplVariantClassic<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantClassic<int, decimal, char, byte, object, long, string, bool>(true);
    //     string? value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         v.Visit(i1 => value = i1.ToString(), s => value = s.ToString(), c => value = c.ToString(), b => value = b.ToString(),
    //             i1 => value = i1.ToString(), s => value = s.ToString(), c => value = c.ToString(), b => value = b.ToString()
    //             );
    //     }
    //
    //     return value;
    // }
    
    // [Benchmark]
    // [BenchmarkCategory("Constructor")]
    // public ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> ImplHandler_Constructor()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(i%2);
    //     }
    //     return v;
    // }
    
    [Benchmark]
    [BenchmarkCategory("Get", "HasStructGetClass")]
    public string ImplHandler_HasStructGetClass()
    {
        ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
        v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
           
            value = v.Get<string>();
        }
        return value;
    }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public bool ImplHandler_Struct()
    {
        ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
        v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
        bool value = false;
        for (int i = 0; i < LoopIterations; i++)
        {
            
            value = v.Get<bool>();
        }
        return value;
    }
    
    // [Benchmark]
    // [BenchmarkCategory("Visit")]
    // public string ImplHandler_Visit()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
    //     string? value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         v.Visit(i1 => value = i1.ToString(), s => value = s.ToString(), c => value = c.ToString(), b => value = b.ToString(),
    //             i1 => value = i1.ToString(), s => value = s.ToString(), c => value = c.ToString(), b => value = b.ToString()
    //         );
    //     }
    //
    //     return value;
    // }
    
    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string ImplHandler_Class()
    {
        ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
        v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>("true");
        string value = null;
        for (int i = 0; i < LoopIterations; i++)
        {
           
            value = v.Get<string>();
        }
        return value;
    }
    
    // [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string ImplHandler_HasStructGetClass_Pattern()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         value = v.GetPattern<string>();
    //     }
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Struct")]
    // public bool ImplHandler_Struct_Pattern()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         value = v.GetPattern<bool>();
    //     }
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Class")]
    // public string ImplHandler_Class_Pattern()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>("true");
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         value = v.GetPattern<string>();
    //     }
    //     return value;
    // }
    //
    //     
    // [Benchmark]
    // [BenchmarkCategory("Get", "HasStructGetClass")]
    // public string ImplHandler_HasStructGetClass_Null()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         value = v.GetNull<string>();
    //     }
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Struct")]
    // public bool ImplHandler_Struct_Null()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>(true);
    //     bool value = false;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         value = v.GetNull<bool>();
    //     }
    //     return value;
    // }
    //
    // [Benchmark]
    // [BenchmarkCategory("Get", "Class")]
    // public string ImplHandler_Class_Null()
    // {
    //     ImplVariantHandler<int, decimal, char, byte, object, long, string, bool> v = null;
    //     v = new ImplVariantHandler<int, decimal, char, byte, object, long, string, bool>("true");
    //     string value = null;
    //     for (int i = 0; i < LoopIterations; i++)
    //     {
    //         
    //         value = v.GetNull<string>();
    //     }
    //     return value;
    // }
}