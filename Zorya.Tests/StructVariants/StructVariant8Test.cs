using System.Drawing;
using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant8Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual('c', v.Get<char>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(typeof(char), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(true, v.TryGet(out char _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string, double, long, float, Point, byte, char> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}