using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant4Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(10L, v.Get<long>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(typeof(long), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(true, v.TryGet(out long _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }
    
    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(4, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4));
    }
}