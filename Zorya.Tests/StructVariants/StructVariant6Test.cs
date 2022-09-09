using System.Drawing;
using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariant6Test
{
    [Test]
    public void GetValue()
    {
        StructVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(new Point(1, 1), v.Get<Point>());
    }

    [Test]
    public void GetSetType()
    {
        StructVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(typeof(Point), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        StructVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(true, v.TryGet(out Point _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        StructVariant<int, string, double, long, float, Point> v;
        v = 10;
        Assert.Throws(typeof(BadStructVariantAccessException), () => v.Get<string>());
    }
}