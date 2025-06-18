using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant4Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        ClassicAssert.AreEqual(10L, v.Get<long>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        ClassicAssert.AreEqual(typeof(long), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        ClassicAssert.AreEqual(true, v.TryGet(out long _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long> v;
        v = 10;
        ClassicAssert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        ClassicAssert.AreEqual(4, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string, double, long> v1 = 10L;
        ValueVariant<int, string, double, long> v2 = 10L;
        ClassicAssert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        ValueVariant<int, string, double, long> v1 = 10;
        ValueVariant<int, string, double, long> v2 = 10L;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string, double, long> v;
        v = 10L;
        ClassicAssert.AreEqual(true, v.IsSet<long>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int, string, double, long> v = 10L;
        ClassicAssert.AreEqual(10L, ValueVariantMarshall.GetValueUnsafe(v));
        v = "test";
        ClassicAssert.AreEqual("test", ValueVariantMarshall.GetValueUnsafe(v));
        v = 5;
        ClassicAssert.AreEqual(5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        ClassicAssert.AreEqual(1.5, ValueVariantMarshall.GetValueUnsafe(v));
    }
}