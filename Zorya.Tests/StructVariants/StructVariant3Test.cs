using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant3Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(10.0, v.Get<double>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(typeof(double), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(true, v.TryGet(out double _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string, double> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}