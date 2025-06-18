using System.Drawing;
using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant8Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        ClassicAssert.AreEqual('c', v.Get<char>());
    }

    [Test]
    public void SetValue()
    {
        Variant<int, string, double, long, float, Point, byte, char> v = new(10);
        var test = v.Set('c');
        Assert.Throws<BadVariantAccessException>(() => v.Get<int>());
        ClassicAssert.AreEqual('c', v.Get<char>());
        ClassicAssert.IsTrue(test);
    }

    [Test]
    public void SetValueFailure()
    {
        Variant<int, string, double, long, float, Point, byte, char> v = new((byte)'c');
        var test = v.Set(20u);
        ClassicAssert.AreEqual((byte)'c', v.Get<byte>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<double>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<uint>());
        ClassicAssert.IsFalse(test);
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        ClassicAssert.AreEqual(typeof(char), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        ClassicAssert.AreEqual(true, v.TryGet(out char _));
        ClassicAssert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 10;
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        ClassicAssert.AreEqual(8, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7, _ => 8));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double, long, float, Point, byte, char> v1 = 'c';
        Variant<int, string, double, long, float, Point, byte, char> v2 = 'c';
        ClassicAssert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        Variant<int, string, double, long, float, Point, byte, char> v1 = 10;
        Variant<int, string, double, long, float, Point, byte, char> v2 = 'c';
        ClassicAssert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        ClassicAssert.AreEqual(true, v.IsSet<char>());
        ClassicAssert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        Variant<int, string, double, long, float, Point, byte, char> v = 'c';
        ClassicAssert.AreEqual('c', VariantMarshall.GetValueUnsafe(v));
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
        v = new Point(1, 1);
        ClassicAssert.AreEqual(new Point(1, 1), VariantMarshall.GetValueUnsafe(v));
        v = (byte)10;
        ClassicAssert.AreEqual((byte)10, VariantMarshall.GetValueUnsafe(v));
    }
}