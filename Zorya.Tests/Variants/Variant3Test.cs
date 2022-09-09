using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant3Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(10.0, v.Get<double>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(typeof(double), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(true, v.TryGet(out double _));
        Assert.AreEqual(false, v.TryGet(out string _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }
}