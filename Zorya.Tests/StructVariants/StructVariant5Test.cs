using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant5Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(10f, v.Get<float>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(typeof(float), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string, double, long, float> v;
        v = 10f;
        Assert.AreEqual(true, v.TryGet(out float _));
        Assert.AreEqual(false, v.TryGet(out string _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string, double, long, float> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}