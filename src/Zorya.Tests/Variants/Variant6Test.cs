using System.Drawing;
using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class Variant6Test
{
    [Test]
    public void GetValue()
    {
        Variant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(new Point(1, 1), v.Get<Point>());
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(typeof(Point), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(true, v.TryGet(out Point _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float, Point> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double, long, float, Point> v;
        v = new Point(1, 1);
        Assert.AreEqual(6, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double, long, float, Point> v1 = new Point(10, 11);
        Variant<int, string, double, long, float, Point> v2 = new Point(10, 11);
        Assert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        Variant<int, string, double, long, float, Point> v1 = 10;
        Variant<int, string, double, long, float, Point> v2 = new Point(10, 11);
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double, long, float, Point> v;
        v = new Point(10, 10);
        Assert.AreEqual(true, v.IsSet<Point>());
        Assert.AreEqual(false, v.IsSet<int>());
    }

    [Test]
    public void GetUnsafe()
    {
        Variant<int, string, double, long, float, Point> v = new Point(1, 1);
        Assert.AreEqual(new Point(1, 1), VariantMarshall.GetValueUnsafe(v));
        v = "test";
        Assert.AreEqual("test", VariantMarshall.GetValueUnsafe(v));
        v = 5;
        Assert.AreEqual(5, VariantMarshall.GetValueUnsafe(v));
        v = 1.5;
        Assert.AreEqual(1.5, VariantMarshall.GetValueUnsafe(v));
        v = 10L;
        Assert.AreEqual(10L, VariantMarshall.GetValueUnsafe(v));
        v = 10f;
        Assert.AreEqual(10f, VariantMarshall.GetValueUnsafe(v));
    }
}