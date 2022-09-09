using System.Drawing;
using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant7Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual((byte) 10, v.Get<byte>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(typeof(byte), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string, double, long, float, Point, byte> v;
        v = (byte) 10;
        Assert.AreEqual(true, v.TryGet(out byte _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string, double, long, float, Point, byte> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}