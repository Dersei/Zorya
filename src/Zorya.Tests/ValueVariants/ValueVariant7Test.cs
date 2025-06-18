using System.Drawing;
using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant7Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual((byte)10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(true, v.TryGet(out byte _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = 10;
        ClassicAssert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(7, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v1 = (byte)10;
        ValueVariant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        ClassicAssert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v1 = 10;
        ValueVariant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(true, v.IsSet<byte>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v = (byte)10;
        ClassicAssert.AreEqual((byte)10, ValueVariantMarshall.GetValueUnsafe(v));
        v = "test";
        ClassicAssert.AreEqual("test", ValueVariantMarshall.GetValueUnsafe(v));
        v = 5;
        ClassicAssert.AreEqual(5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        ClassicAssert.AreEqual(1.5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 10L;
        ClassicAssert.AreEqual(10L, ValueVariantMarshall.GetValueUnsafe(v));
        v = 10f;
        ClassicAssert.AreEqual(10f, ValueVariantMarshall.GetValueUnsafe(v));
        v = new Point(1, 1);
        ClassicAssert.AreEqual(new Point(1, 1), ValueVariantMarshall.GetValueUnsafe(v));
    }
}