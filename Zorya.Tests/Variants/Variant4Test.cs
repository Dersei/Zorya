using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant4Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(10L, v.Get<long>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(typeof(long), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(true, v.TryGet(out long _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }
    
    [Test]
    public void Visit()
    {
        Variant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(4, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4));
    }
}