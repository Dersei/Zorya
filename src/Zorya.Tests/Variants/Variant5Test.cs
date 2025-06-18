using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant5Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(10f, v.Get<float>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(typeof(float), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(true, v.TryGet(out float _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(5, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double, long, float> v1 = 10f;
        Variant<int, string, double, long, float> v2 = 10f;
        Assert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        Variant<int, string, double, long, float> v1 = 10;
        Variant<int, string, double, long, float> v2 = 10f;
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(true, v.IsSet<float>());
        Assert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        Variant<int, string, double, long, float> v = 10f;
        Assert.AreEqual(10f, VariantMarshall.GetValueUnsafe(v));
        v = "test";
        Assert.AreEqual("test", VariantMarshall.GetValueUnsafe(v));
        v = 5;
        Assert.AreEqual(5, VariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        Assert.AreEqual(1.5, VariantMarshall.GetValueUnsafe(v));
        v = 10L;
        Assert.AreEqual(10L, VariantMarshall.GetValueUnsafe(v));
    }
}