using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant4Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(10L, v.Get<long>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(typeof(long), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string, double, long> v;
        v = 10L;
        Assert.AreEqual(true, v.TryGet(out long _));
        Assert.AreEqual(false, v.TryGet(out string _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string, double, long> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}