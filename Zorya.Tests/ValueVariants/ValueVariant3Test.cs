using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant3Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(10.0, v.Get<double>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(typeof(double), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(true, v.TryGet(out double _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }
    
    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double> v;
        v = 10.0;
        Assert.AreEqual(3, v.Visit(_ => 1, _ => 2, _ => 3));
    }
}