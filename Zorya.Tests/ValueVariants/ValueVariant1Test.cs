using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant1Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int> v;
        v = 10;
        Assert.AreEqual(10, v.Get<int>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int> v;
        v = 10;
        Assert.AreEqual(typeof(int), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int> v;
        v = 10;
        Assert.AreEqual(true, v.TryGet(out int _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }
}