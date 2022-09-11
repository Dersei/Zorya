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
}