using System;
using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class VariantGeneralTest
{
    [Test]
    public void Match()
    {
        Variant<int, string, double> v;
        v = 10;
        Assert.AreEqual(100, v.Match((int i) => i * 10));
        v = "10";
        Assert.AreEqual("1010", v.Match((string s) => s + 10));
    }

    [Test]
    public void SetValue()
    {
        Variant<int, string> v = new(10);
        var test = v.Set((string)null!);
        Assert.IsFalse(test);
    }
    
    [Test]
    public void MatchFail()
    {
        Variant<int, string, double> v;
        v = 10;
        Assert.Throws<BadVariantAccessException>(() => v.Match((string s) => s + 10));
    }

    [Test]
    public void MatchOrDefault()
    {
        Variant<int, string, double> v;
        v = 10;
        Assert.AreEqual(100, v.MatchOrDefault((int i) => i * 10, 11));
        v = "10";
        Assert.AreEqual("1010", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void MatchOrDefaultFail()
    {
        Variant<int, string, double> v;
        v = "10";
        Assert.AreEqual(11, v.MatchOrDefault((int i) => i * 10, 11));
        v = 10;
        Assert.AreEqual("1000", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void TryMatch()
    {
        Variant<int, string, double> v;
        v = 10;
        var test = v.TryMatch((int i) => i * 10, out var result);
        Assert.AreEqual(true, test);
        Assert.AreEqual(100, result);
    }

    [Test]
    public void TryMatchFail()
    {
        Variant<int, string, double> v;
        v = "10";
        var test = v.TryMatch((int i) => i * 10, out _);
        Assert.AreEqual(false, test);
    }

    [Test]
    public void ReferenceTypes()
    {
        Variant<object, string, TestExampleRef> v;
        var refT = new TestExampleRef();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleRef>());
    }

    [Test]
    public void ReferenceTypesEquality()
    {
        Variant<object, string, TestExampleEqual> v;
        v = new TestExampleEqual(10);
        Assert.AreEqual(new TestExampleEqual(10), v.Get<TestExampleEqual>());
    }
    
    [Test]
    public void TestToString()
    {
        Variant<object, string, TestExampleEqual> v = "test";
        Assert.True(v.ToString().Contains("test"));
        v = new TestExampleEqual(10);
        Assert.True(v.ToString().Contains(nameof(TestExampleEqual)));
        Assert.False(v.ToString().Contains("test"));
    }
    
    [Test]
    public void CheckIfValid()
    {
        var v = new Variant<object, string>(null!);
        Assert.False(v.IsValid());
        
        v = "test";
        Assert.True(v.IsValid());
        
        Variant<int, TestExampleEqual> v2 = null!;
        Assert.False(v2.IsValid());
        
        Variant<int, TestExampleEqual> v3 = 1;
        Assert.True(v3.IsValid());

        v3 = null!;
        Assert.False(v3.IsValid());
    }

    [Test]
    public void TestNullCases()
    {
        Variant<int, string, double, long, float, byte, char> v = new(null!);
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
        Assert.AreEqual(null, v.GetSetType());
        Assert.False(v.TryGet(out string? _));
        Assert.AreEqual(0, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
        Variant<int, string> v1 = new(null!);
        Variant<int, string> v2 = new(null!);
        Assert.AreEqual(v1, v2);
        Assert.False(v.IsSet<string>());

        var value = 0;
        v.Visit(_ => value = 1, _ => value = 2, _ => value = 3, _ => value = 4, _ => value = 5, _ => value = 6,
            _ => value = 7);
        Assert.AreEqual(0, value);
    }

    private class TestExampleRef
    {
    }

    private class TestExampleEqual : IEquatable<TestExampleEqual>
    {
        public readonly int Id;

        public TestExampleEqual(int id)
        {
            Id = id;
        }

        public bool Equals(TestExampleEqual? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TestExampleEqual)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}