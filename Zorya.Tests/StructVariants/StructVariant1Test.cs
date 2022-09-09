using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant1Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int> v;
        v = 10;
        Assert.AreEqual(10, v.Get<int>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int> v;
        v = 10;
        Assert.AreEqual(typeof(int), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int> v;
        v = 10;
        Assert.AreEqual(true, v.TryGet(out int _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}