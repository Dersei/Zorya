using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant5Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        ClassicAssert.AreEqual(10f, v.Get<float>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        ClassicAssert.AreEqual(typeof(float), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        ClassicAssert.AreEqual(true, v.TryGet(out float _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10;
        ClassicAssert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        ClassicAssert.AreEqual(5, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string, double, long, float> v1 = 10f;
        ValueVariant<int, string, double, long, float> v2 = 10f;
        ClassicAssert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        ValueVariant<int, string, double, long, float> v1 = 10;
        ValueVariant<int, string, double, long, float> v2 = 10f;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string, double, long, float> v;
        v = 10f;
        ClassicAssert.AreEqual(true, v.IsSet<float>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int, string, double, long, float> v = 10f;
        ClassicAssert.AreEqual(10f, ValueVariantMarshall.GetValueUnsafe(v));
        v = "test";
        ClassicAssert.AreEqual("test", ValueVariantMarshall.GetValueUnsafe(v));
        v = 5;
        ClassicAssert.AreEqual(5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        ClassicAssert.AreEqual(1.5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 10L;
        ClassicAssert.AreEqual(10L, ValueVariantMarshall.GetValueUnsafe(v));
    }
}