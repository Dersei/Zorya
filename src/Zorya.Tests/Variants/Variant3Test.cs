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
        Assert.AreEqual(10.0, v.Get<double>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(typeof(double), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(true, v.TryGet(out double _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(3, v.Visit(_ => 1, _ => 2, _ => 3));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double> v1 = 10.0;
        Variant<int, string, double> v2 = 10.0;
        Assert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        Variant<int, string, double> v1 = "test";
        Variant<int, string, double> v2 = 10.0;
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(true, v.IsSet<double>());
        Assert.AreEqual(false, v.IsSet<int>());
    }
}