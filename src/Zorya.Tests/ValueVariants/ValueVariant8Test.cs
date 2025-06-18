using System.Drawing;
using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant8Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual('c', v.Get<char>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(typeof(char), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(true, v.TryGet(out char _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(8, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7, _ => 8));
    }
    
    [Test]
    public void Equality()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v1 = 'c';
        ValueVariant<int, string, double, long, float, Point, byte, char> v2 = 'c';
        Assert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v1 = 10;
        ValueVariant<int, string, double, long, float, Point, byte, char> v2 = 'c';
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(true, v.IsSet<char>());
        Assert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        ValueVariant<int, string, double, long, float, Point, byte, char> v = 'c';
        Assert.AreEqual('c', ValueVariantMarshall.GetValueUnsafe(v));
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
        v = (byte)10;
        Assert.AreEqual((byte)10, ValueVariantMarshall.GetValueUnsafe(v));
    }
}