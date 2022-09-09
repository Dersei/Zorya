using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant2Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string> v = "10";
        Assert.AreEqual("10", v.Get<string>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string> v;
        v = "10";
        Assert.AreEqual(typeof(string), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string> v;
        v = "10";
        Assert.AreEqual(true, v.TryGet(out string? _));
        Assert.AreEqual(false, v.TryGet(out int _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}