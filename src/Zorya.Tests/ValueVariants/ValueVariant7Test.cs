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
        Assert.AreEqual((byte)10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(true, v.TryGet(out byte _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(7, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v1 = (byte)10;
        ValueVariant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        Assert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v1 = 10;
        ValueVariant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(true, v.IsSet<byte>());
        Assert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int, string, double, long, float, Point, byte> v = (byte)10;
        Assert.AreEqual((byte)10, ValueVariantMarshall.GetValueUnsafe(v));
        v = "test";
        Assert.AreEqual("test", ValueVariantMarshall.GetValueUnsafe(v));
        v = 5;
        Assert.AreEqual(5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        Assert.AreEqual(1.5, ValueVariantMarshall.GetValueUnsafe(v));
        v = 10L;
        Assert.AreEqual(10L, ValueVariantMarshall.GetValueUnsafe(v));
        v = 10f;
        Assert.AreEqual(10f, ValueVariantMarshall.GetValueUnsafe(v));
        v = new Point(1, 1);
        Assert.AreEqual(new Point(1, 1), ValueVariantMarshall.GetValueUnsafe(v));
    }
}