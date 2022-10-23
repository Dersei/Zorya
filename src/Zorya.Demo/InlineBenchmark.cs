using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;

namespace Zorya.Demo;

[DisassemblyDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[AnyCategoriesFilter("Visit")]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[InliningDiagnoser(false, new[] { nameof(Variants), nameof(ValueVariants) })]
public class InlineBenchmark
{
    private const int LoopIterations = 100;

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get", "Struct")]
    public string TryGet()
    {
        var r = false;
        var rs = string.Empty;
        bool test = false;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            test = v.TryGet<int>(out var i);
            test |= v.TryGet<decimal>(out var d);
            test |= v.TryGet<char>(out var c);
            test |= v.TryGet<byte>(out var b);
            test |= v.TryGet<object>(out var o);
            test |= v.TryGet<long>(out var l);
            test |= v.TryGet<string>(out var s);
            rs = "" + i + d + c + b + o + l + s;
            if (test && d > 110)
            {
                Console.WriteLine(d);
            }

            if (test && c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (test && b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (test && o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (test && l > 10)
            {
                Console.WriteLine(l * 2);
            }

            test = v.TryGet<bool>(out r);
        }

        Trace.Assert(test);
        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string TryGet_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;
        bool test = false;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            test = v.TryGet<int>(out var i);
            test |= v.TryGet<decimal>(out var d);
            test |= v.TryGet<char>(out var c);
            test |= v.TryGet<byte>(out var b);
            test |= v.TryGet<object>(out var o);
            test |= v.TryGet<long>(out var l);
            test |= v.TryGet<bool>(out var s);
            rs = "" + i + d + c + b + o + l + s;
            if (test && d > 110)
            {
                Console.WriteLine(d);
            }

            if (test && c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (test && b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (test && o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (test && l > 10)
            {
                Console.WriteLine(l * 2);
            }

            test = v.TryGet<string>(out r);
        }

        Trace.Assert(test);
        Trace.Assert(r == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string TryGet_Inline()
    {
        var r = false;
        var rs = string.Empty;
        bool test = false;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            test = v.TryGetInline<int>(out var i);
            test |= v.TryGetInline<decimal>(out var d);
            test |= v.TryGetInline<char>(out var c);
            test |= v.TryGetInline<byte>(out var b);
            test |= v.TryGetInline<object>(out var o);
            test |= v.TryGetInline<long>(out var l);
            test |= v.TryGetInline<string>(out var s);
            rs = "" + i + d + c + b + o + l + s;
            if (test && d > 110)
            {
                Console.WriteLine(d);
            }

            if (test && c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (test && b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (test && o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (test && l > 10)
            {
                Console.WriteLine(l * 2);
            }

            test = v.TryGetInline<bool>(out r);
        }

        Trace.Assert(test);
        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string TryGet_Class_Inline()
    {
        var r = string.Empty;
        var rs = string.Empty;
        bool test = false;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            test = v.TryGetInline<int>(out var i);
            test |= v.TryGetInline<decimal>(out var d);
            test |= v.TryGetInline<char>(out var c);
            test |= v.TryGetInline<byte>(out var b);
            test |= v.TryGetInline<object>(out var o);
            test |= v.TryGetInline<long>(out var l);
            test |= v.TryGetInline<bool>(out var s);
            rs = "" + i + d + c + b + o + l + s;
            if (test && d > 110)
            {
                Console.WriteLine(d);
            }

            if (test && c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (test && b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (test && o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (test && l > 10)
            {
                Console.WriteLine(l * 2);
            }

            test = v.TryGetInline<string>(out r);
        }

        Trace.Assert(test);
        Trace.Assert(r == "true");
        return rs;
    }
    
      [Benchmark(Baseline = true)]
    [BenchmarkCategory("Visit", "Struct")]
    public string Visit()
    {
        var rs = string.Empty;
        bool boo1 = default;
        for (var j = 0; j < LoopIterations; j++)
        {
            int i1 = 0;
            decimal arg = 0;
            char ch1 = default;
            byte b1 = default;
            object o1 = default;
            long l1 = default;
            string s1 = default;
           
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (arg > 110)
            {
                Console.WriteLine(arg);
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (ch1 > 120)
            {
                Console.WriteLine(arg + ch1);
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (b1 > 100)
            {
                Console.WriteLine(b1 + arg + ch1);
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (o1 is double)
            {
                Console.WriteLine(o1.ToString());
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (l1 > 10)
            {
                Console.WriteLine(l1 * 2);
            }
            
        }

        Trace.Assert(boo1);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Visit", "Class")]
    public string Visit_Class()
    {
        var rs = string.Empty;
        bool boo1 = default;
        for (var j = 0; j < LoopIterations; j++)
        {
            int i1 = 0;
            decimal arg = 0;
            char ch1 = default;
            byte b1 = default;
            object o1 = default;
            long l1 = default;
            string s1 = default;
           
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (arg > 110)
            {
                Console.WriteLine(arg);
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (ch1 > 120)
            {
                Console.WriteLine(arg + ch1);
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (b1 > 100)
            {
                Console.WriteLine(b1 + arg + ch1);
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (o1 is double)
            {
                Console.WriteLine(o1.ToString());
            }
            v.Visit(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (l1 > 10)
            {
                Console.WriteLine(l1 * 2);
            }
            
        }

        Trace.Assert(rs == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Visit", "Struct")]
    public string Visit_Inline()
    {
        var rs = string.Empty;
        bool boo1 = default;
        for (var j = 0; j < LoopIterations; j++)
        {
            int i1 = 0;
            decimal arg = 0;
            char ch1 = default;
            byte b1 = default;
            object o1 = default;
            long l1 = default;
            string s1 = default;
           
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (arg > 110)
            {
                Console.WriteLine(arg);
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (ch1 > 120)
            {
                Console.WriteLine(arg + ch1);
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (b1 > 100)
            {
                Console.WriteLine(b1 + arg + ch1);
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (o1 is double)
            {
                Console.WriteLine(o1.ToString());
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (l1 > 10)
            {
                Console.WriteLine(l1 * 2);
            }
            
        }

        Trace.Assert(boo1);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Visit", "Class")]
    public string Visit_Class_Inline()
    {
        var rs = string.Empty;
        bool boo1 = default;
        for (var j = 0; j < LoopIterations; j++)
        {
            int i1 = 0;
            decimal arg = 0;
            char ch1 = default;
            byte b1 = default;
            object o1 = default;
            long l1 = default;
            string s1 = default;
           
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (arg > 110)
            {
                Console.WriteLine(arg);
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (ch1 > 120)
            {
                Console.WriteLine(arg + ch1);
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (b1 > 100)
            {
                Console.WriteLine(b1 + arg + ch1);
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (o1 is double)
            {
                Console.WriteLine(o1.ToString());
            }
            v.VisitInline(_ => i1 = 1, _ => arg = 1, _ => ch1 = 'c', _ => b1 = 1, _ => o1 = new object(), _ => l1 = 10, _ => rs = "true", _ => boo1 = true);
            if (l1 > 10)
            {
                Console.WriteLine(l1 * 2);
            }
            
        }

        Trace.Assert(rs == "true");
        return rs;
    }
}