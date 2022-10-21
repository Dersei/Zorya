using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant5Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(10f, v.Get<float>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(typeof(float), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(true, v.TryGet(out float _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(5, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string, double, long, float> v1 = 10f;
        ValueVariant<int, string, double, long, float> v2 = 10f;
        Assert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        ValueVariant<int, string, double, long, float> v1 = 10;
        ValueVariant<int, string, double, long, float> v2 = 10f;
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(true, v.IsSet<float>());
        Assert.AreEqual(false, v.IsSet<int>());
    }
}