using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant2Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string> v = "10";
        Assert.AreEqual("10", v.Get<string>());
    }
    
    [Test]
    public void SetValue()
    {
        Variant<int, string> v = new (10);
        var test = v.Set("20");
        Assert.Throws<BadVariantAccessException>(() => v.Get<int>());
        Assert.AreEqual("20", v.Get<string>());
        Assert.IsTrue(test);
    }
    
    [Test]
    public void SetValueFailure()
    {
        Variant<int, string> v = new (10);
        var test = v.Set(20.0);
        Assert.AreEqual(10, v.Get<int>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<double>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
        Assert.IsFalse(test);
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string> v;
        v = "10";
        Assert.AreEqual(typeof(string), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string> v;
        v = "10";
        Assert.AreEqual(true, v.TryGet(out string? _));
        Assert.AreEqual(false, v.TryGet(out int _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }
}