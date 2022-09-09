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
}