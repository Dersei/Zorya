using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant1Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int> v;
        v = 10;
        ClassicAssert.AreEqual(10, v.Get<int>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int> v;
        v = 10;
        ClassicAssert.AreEqual(typeof(int), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int> v;
        v = 10;
        ClassicAssert.AreEqual(true, v.TryGet(out int _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int> v;
        v = 10;
        ClassicAssert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int> v;
        v = 10;
        ClassicAssert.AreEqual(1, v.Visit(_ => 1));
    }

    [Test]
    public void Equality()
    {
        ValueVariant<string> v1 = "test";
        ValueVariant<string> v2 = "test";
        ClassicAssert.AreEqual(v1, v2);
    }
    
    [Test]
    public void Inequality()
    {
        ValueVariant<int> v1 = 11;
        ValueVariant<int> v2 = 10;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int> v;
        v = 10;
        ClassicAssert.AreEqual(true, v.IsSet<int>());
        ClassicAssert.AreEqual(false, v.IsSet<string>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int> v = 10;
        ClassicAssert.AreEqual(10, ValueVariantMarshall.GetValueUnsafe(v));
    }
}