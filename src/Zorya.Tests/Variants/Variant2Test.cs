using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant2Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string> v = "10";
        ClassicAssert.AreEqual("10", v.Get<string>());
    }

    [Test]
    public void SetValue()
    {
        Variant<int, string> v = new(10);
        var test = v.Set("20");
        Assert.Throws<BadVariantAccessException>(() => v.Get<int>());
        ClassicAssert.AreEqual("20", v.Get<string>());
        ClassicAssert.IsTrue(test);
    }

    [Test]
    public void SetValueFailure()
    {
        Variant<int, string> v = new(10);
        var test = v.Set(20.0);
        ClassicAssert.AreEqual(10, v.Get<int>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<double>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
        ClassicAssert.IsFalse(test);
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string> v;
        v = "10";
        ClassicAssert.AreEqual(typeof(string), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string> v;
        v = "10";
        ClassicAssert.AreEqual(true, v.TryGet(out string? _));
        ClassicAssert.AreEqual(false, v.TryGet(out int _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string> v;
        v = 10;
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string> v = "10";
        ClassicAssert.AreEqual(2, v.Visit(_ => 1, _ => 2));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string> v1 = "test";
        Variant<int, string> v2 = "test";
        ClassicAssert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        Variant<int, string> v1 = "test";
        Variant<int, string> v2 = 10;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string> v;
        v = "10";
        ClassicAssert.AreEqual(true, v.IsSet<string>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        Variant<int, string> v = 10;
        ClassicAssert.AreEqual(10, VariantMarshall.GetValueUnsafe(v));
        v = "test";
        ClassicAssert.AreEqual("test", VariantMarshall.GetValueUnsafe(v));
    }
}