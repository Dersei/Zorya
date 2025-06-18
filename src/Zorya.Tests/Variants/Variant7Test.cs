using System.Drawing;
using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant7Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual((byte)10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(true, v.TryGet(out byte _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = 10;
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(7, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double, long, float, Point, byte> v1 = (byte)10;
        Variant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        ClassicAssert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        Variant<int, string, double, long, float, Point, byte> v1 = 10;
        Variant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        ClassicAssert.AreEqual(true, v.IsSet<byte>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        Variant<int, string, double, long, float, Point, byte> v = (byte)10;
        ClassicAssert.AreEqual((byte)10, VariantMarshall.GetValueUnsafe(v));
        v = "test";
        ClassicAssert.AreEqual("test", VariantMarshall.GetValueUnsafe(v));
        v = 5;
        ClassicAssert.AreEqual(5, VariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        ClassicAssert.AreEqual(1.5, VariantMarshall.GetValueUnsafe(v));
        v = 10L;
        ClassicAssert.AreEqual(10L, VariantMarshall.GetValueUnsafe(v));
        v = 10f;
        ClassicAssert.AreEqual(10f, VariantMarshall.GetValueUnsafe(v));
        v = new System.Drawing.Point(1, 1);
        ClassicAssert.AreEqual(new System.Drawing.Point(1, 1), VariantMarshall.GetValueUnsafe(v));
    }
}