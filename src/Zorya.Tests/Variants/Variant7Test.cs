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
        Assert.AreEqual((byte)10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(true, v.TryGet(out byte _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(7, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double, long, float, Point, byte> v1 = (byte)10;
        Variant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        Assert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        Variant<int, string, double, long, float, Point, byte> v1 = 10;
        Variant<int, string, double, long, float, Point, byte> v2 = (byte)10;
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte)10;
        Assert.AreEqual(true, v.IsSet<byte>());
        Assert.AreEqual(false, v.IsSet<int>());
    }
}