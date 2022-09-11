using System.Drawing;
using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariant6Test
{
    [Test]
    public void GetValue()
    {
        ValueVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(new Point(1, 1), v.Get<Point>());
    }

    [Test]
    public void GetSetType()
    {
        ValueVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(typeof(Point), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        ValueVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(true, v.TryGet(out Point _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        ValueVariant<int, string, double, long, float, Point> v;
        v = 10;
        Assert.Throws(typeof(BadValueVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        ValueVariant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(6, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6));
    }
}