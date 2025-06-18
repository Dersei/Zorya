using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant3Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double> v;
        v = 10.0;
        ClassicAssert.AreEqual(10.0, v.Get<double>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double> v;
        v = 10.0;
        ClassicAssert.AreEqual(typeof(double), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double> v;
        v = 10.0;
        ClassicAssert.AreEqual(true, v.TryGet(out double _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double> v;
        v = 10;
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double> v;
        v = 10.0;
        ClassicAssert.AreEqual(3, v.Visit(_ => 1, _ => 2, _ => 3));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double> v1 = 10.0;
        Variant<int, string, double> v2 = 10.0;
        ClassicAssert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        Variant<int, string, double> v1 = "test";
        Variant<int, string, double> v2 = 10.0;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double> v;
        v = 10.0;
        ClassicAssert.AreEqual(true, v.IsSet<double>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        Variant<int, string, double> v = 10.0;
        ClassicAssert.AreEqual(10.0, VariantMarshall.GetValueUnsafe(v));
        v = "test";
        ClassicAssert.AreEqual("test", VariantMarshall.GetValueUnsafe(v));
        v = 5;
        ClassicAssert.AreEqual(5, VariantMarshall.GetValueUnsafe(v));
    }
}