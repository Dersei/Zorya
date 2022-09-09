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
        v = (byte) 10;
        Assert.AreEqual((byte) 10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(true, v.TryGet(out byte _));
        Assert.AreEqual(false, v.TryGet(out string _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float, Point, byte> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }
}