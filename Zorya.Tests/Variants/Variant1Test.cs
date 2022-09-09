using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Tests
{
    [Test]
    public void GetValue()
    {
        Variant<int> v;
        v = 10;
        Assert.AreEqual(10, v.Get<int>());
    }
    
    [Test]
    public void SetValue()
    {
        Variant<int> v = new (10);
        var test = v.Set(20);
        Assert.AreEqual(20, v.Get<int>());
        Assert.IsTrue(test);
    }


    [Test]
    public void GetSetType()
    {
        Variant<int> v;
        v = 10;
        Assert.AreEqual(typeof(int), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int> v;
        v = 10;
        Assert.AreEqual(true, v.TryGet(out int _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }
}