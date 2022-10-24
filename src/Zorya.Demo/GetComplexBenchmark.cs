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
[InliningDiagnoser(false, new[] { nameof(Variants), nameof(ValueVariants) })]
public class GetComplexBenchmark
{
    private const int LoopIterations = 100;

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Get", "Struct")]
    public string GetStandardComplex()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetStandard<int>();
            var d = v.GetStandard<decimal>();
            var c = v.GetStandard<char>();
            var b = v.GetStandard<byte>();
            var o = v.GetStandard<object>();
            var l = v.GetStandard<long>();
            var s = v.GetStandard<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetStandard<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetStandardComplex_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetStandard<int>();
            var d = v.GetStandard<decimal>();
            var c = v.GetStandard<char>();
            var b = v.GetStandard<byte>();
            var o = v.GetStandard<object>();
            var l = v.GetStandard<long>();
            var s = v.GetStandard<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetStandard<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetStandardComplex_Inline()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetStandardInline<int>();
            var d = v.GetStandardInline<decimal>();
            var c = v.GetStandardInline<char>();
            var b = v.GetStandardInline<byte>();
            var o = v.GetStandardInline<object>();
            var l = v.GetStandardInline<long>();
            var s = v.GetStandardInline<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetStandardInline<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetStandardComplex_Class_Inline()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetStandardInline<int>();
            var d = v.GetStandardInline<decimal>();
            var c = v.GetStandardInline<char>();
            var b = v.GetStandardInline<byte>();
            var o = v.GetStandardInline<object>();
            var l = v.GetStandardInline<long>();
            var s = v.GetStandardInline<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetStandardInline<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    //###########################

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetDoubleCheckComplex()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetDoubleCheck<int>();
            var d = v.GetDoubleCheck<decimal>();
            var c = v.GetDoubleCheck<char>();
            var b = v.GetDoubleCheck<byte>();
            var o = v.GetDoubleCheck<object>();
            var l = v.GetDoubleCheck<long>();
            var s = v.GetDoubleCheck<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetDoubleCheck<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetDoubleCheckComplex_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetDoubleCheck<int>();
            var d = v.GetDoubleCheck<decimal>();
            var c = v.GetDoubleCheck<char>();
            var b = v.GetDoubleCheck<byte>();
            var o = v.GetDoubleCheck<object>();
            var l = v.GetDoubleCheck<long>();
            var s = v.GetDoubleCheck<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetDoubleCheck<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetDoubleCheckComplex_Inline()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetDoubleCheckInline<int>();
            var d = v.GetDoubleCheckInline<decimal>();
            var c = v.GetDoubleCheckInline<char>();
            var b = v.GetDoubleCheckInline<byte>();
            var o = v.GetDoubleCheckInline<object>();
            var l = v.GetDoubleCheckInline<long>();
            var s = v.GetDoubleCheckInline<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetDoubleCheckInline<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetDoubleCheckComplex_Class_Inline()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetDoubleCheckInline<int>();
            var d = v.GetDoubleCheckInline<decimal>();
            var c = v.GetDoubleCheckInline<char>();
            var b = v.GetDoubleCheckInline<byte>();
            var o = v.GetDoubleCheckInline<object>();
            var l = v.GetDoubleCheckInline<long>();
            var s = v.GetDoubleCheckInline<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetDoubleCheckInline<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    //##########################

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetUnsafeComplex()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetUnsafe<int>();
            var d = v.GetUnsafe<decimal>();
            var c = v.GetUnsafe<char>();
            var b = v.GetUnsafe<byte>();
            var o = v.GetUnsafe<object>();
            var l = v.GetUnsafe<long>();
            var s = v.GetUnsafe<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafe<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeComplex_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetUnsafe<int>();
            var d = v.GetUnsafe<decimal>();
            var c = v.GetUnsafe<char>();
            var b = v.GetUnsafe<byte>();
            var o = v.GetUnsafe<object>();
            var l = v.GetUnsafe<long>();
            var s = v.GetUnsafe<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafe<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetUnsafeComplex_Inline()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetUnsafeInline<int>();
            var d = v.GetUnsafeInline<decimal>();
            var c = v.GetUnsafeInline<char>();
            var b = v.GetUnsafeInline<byte>();
            var o = v.GetUnsafeInline<object>();
            var l = v.GetUnsafeInline<long>();
            var s = v.GetUnsafeInline<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafeInline<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeComplex_Class_Inline()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetUnsafeInline<int>();
            var d = v.GetUnsafeInline<decimal>();
            var c = v.GetUnsafeInline<char>();
            var b = v.GetUnsafeInline<byte>();
            var o = v.GetUnsafeInline<object>();
            var l = v.GetUnsafeInline<long>();
            var s = v.GetUnsafeInline<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafeInline<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    //#####################################

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetUnsafeNullCheckComplex()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetUnsafeNullCheck<int>();
            var d = v.GetUnsafeNullCheck<decimal>();
            var c = v.GetUnsafeNullCheck<char>();
            var b = v.GetUnsafeNullCheck<byte>();
            var o = v.GetUnsafeNullCheck<object>();
            var l = v.GetUnsafeNullCheck<long>();
            var s = v.GetUnsafeNullCheck<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafeNullCheck<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeNullCheckComplex_Class()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetUnsafeNullCheck<int>();
            var d = v.GetUnsafeNullCheck<decimal>();
            var c = v.GetUnsafeNullCheck<char>();
            var b = v.GetUnsafeNullCheck<byte>();
            var o = v.GetUnsafeNullCheck<object>();
            var l = v.GetUnsafeNullCheck<long>();
            var s = v.GetUnsafeNullCheck<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafeNullCheck<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Struct")]
    public string GetUnsafeNullCheckComplex_Inline()
    {
        var r = false;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
            var i = v.GetUnsafeNullCheckInline<int>();
            var d = v.GetUnsafeNullCheckInline<decimal>();
            var c = v.GetUnsafeNullCheckInline<char>();
            var b = v.GetUnsafeNullCheckInline<byte>();
            var o = v.GetUnsafeNullCheckInline<object>();
            var l = v.GetUnsafeNullCheckInline<long>();
            var s = v.GetUnsafeNullCheckInline<string>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafeNullCheckInline<bool>();
        }

        Trace.Assert(r);
        return rs;
    }

    [Benchmark]
    [BenchmarkCategory("Get", "Class")]
    public string GetUnsafeNullCheckComplex_Class_Inline()
    {
        var r = string.Empty;
        var rs = string.Empty;

        for (var j = 0; j < LoopIterations; j++)
        {
            var v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
            var i = v.GetUnsafeNullCheckInline<int>();
            var d = v.GetUnsafeNullCheckInline<decimal>();
            var c = v.GetUnsafeNullCheckInline<char>();
            var b = v.GetUnsafeNullCheckInline<byte>();
            var o = v.GetUnsafeNullCheckInline<object>();
            var l = v.GetUnsafeNullCheckInline<long>();
            var s = v.GetUnsafeNullCheckInline<bool>();
            rs = "" + i + d + c + b + o + l + s;
            if (d > 110)
            {
                Console.WriteLine(d);
            }

            if (c > 120)
            {
                Console.WriteLine(d + c);
            }

            if (b > 100)
            {
                Console.WriteLine(b + d + c);
            }

            if (o is double)
            {
                Console.WriteLine(o.ToString());
            }

            if (l > 10)
            {
                Console.WriteLine(l * 2);
            }

            r = v.GetUnsafeNullCheckInline<string>();
        }

        Trace.Assert(r == "true");
        return rs;
    }
}