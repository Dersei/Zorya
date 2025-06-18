using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant2Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string> v = "10";
        Assert.AreEqual("10", v.Get<string>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string> v;
        v = "10";
        Assert.AreEqual(typeof(string), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string> v;
        v = "10";
        Assert.AreEqual(true, v.TryGet(out string? _));
        Assert.AreEqual(false, v.TryGet(out int _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string> v = "10";
        Assert.AreEqual(2, v.Visit(_ => 1, _ => 2));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string> v1 = "test";
        ValueVariant<int, string> v2 = "test";
        Assert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        ValueVariant<int, string> v1 = "test";
        ValueVariant<int, string> v2 = 10;
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string> v;
        v = "10";
        Assert.AreEqual(true, v.IsSet<string>());
        Assert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int, string> v = 10;
        Assert.AreEqual(10, ValueVariantMarshall.GetValueUnsafe(v));
        v = "test";
        Assert.AreEqual("test", ValueVariantMarshall.GetValueUnsafe(v));
    }
}