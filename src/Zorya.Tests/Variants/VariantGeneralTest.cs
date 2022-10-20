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
        var test = v.TryMatch((int i) => i * 10, out var result);
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