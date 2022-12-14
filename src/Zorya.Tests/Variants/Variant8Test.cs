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
        Assert.AreEqual('c', v.Get<char>());
    }

    [Test]
    public void SetValue()
    {
        Variant<int, string, double, long, float, Point, byte, char> v = new(10);
        var test = v.Set('c');
        Assert.Throws<BadVariantAccessException>(() => v.Get<int>());
        Assert.AreEqual('c', v.Get<char>());
        Assert.IsTrue(test);
    }

    [Test]
    public void SetValueFailure()
    {
        Variant<int, string, double, long, float, Point, byte, char> v = new((byte)'c');
        var test = v.Set(20u);
        Assert.AreEqual((byte)'c', v.Get<byte>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<double>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
        Assert.Throws<BadVariantAccessException>(() => v.Get<uint>());
        Assert.IsFalse(test);
    }

    [Test]
    public void GetSetType()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(typeof(char), v.GetSetType());
    }

    [Test]
    public void TryGetValue()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(true, v.TryGet(out char _));
        Assert.AreEqual(false, v.TryGet(out string? _));
    }

    [Test]
    public void ThrowException()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 10;
        Assert.Throws(typeof(BadVariantAccessException), () => v.Get<string>());
    }

    [Test]
    public void Visit()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(8, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7, _ => 8));
    }
    
    [Test]
    public void Equality()
    {
        Variant<int, string, double, long, float, Point, byte, char> v1 = 'c';
        Variant<int, string, double, long, float, Point, byte, char> v2 = 'c';
        Assert.AreEqual(v1, v2);
    }

    [Test]
    public void Inequality()
    {
        Variant<int, string, double, long, float, Point, byte, char> v1 = 10;
        Variant<int, string, double, long, float, Point, byte, char> v2 = 'c';
        Assert.AreNotEqual(v1, v2);
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, string, double, long, float, Point, byte, char> v;
        v = 'c';
        Assert.AreEqual(true, v.IsSet<char>());
        Assert.AreEqual(false, v.IsSet<int>());
    }
}