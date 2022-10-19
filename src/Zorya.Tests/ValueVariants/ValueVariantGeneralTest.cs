using System;
using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariantGeneralTest
{
    [Test]
    public void Match()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        Assert.AreEqual(100, v.Match((int i) => i * 10));
        v = "10";
        Assert.AreEqual("1010", v.Match((string s) => s + 10));
    }

    [Test]
    public void MatchFail()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        Assert.Throws<BadValueVariantAccessException>(() => v.Match((string s) => s + 10));
    }

    [Test]
    public void MatchOrDefault()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        Assert.AreEqual(100, v.MatchOrDefault((int i) => i * 10, 11));
        v = "10";
        Assert.AreEqual("1010", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void MatchOrDefaultFail()
    {
        ValueVariant<int, string, double> v;
        v = "10";
        Assert.AreEqual(11, v.MatchOrDefault((int i) => i * 10, 11));
        v = 10;
        Assert.AreEqual("1000", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void TryMatch()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        var test = v.TryMatch((int i) => i * 10, out var result);
        Assert.AreEqual(true, test);
        Assert.AreEqual(100, result);
    }

    [Test]
    public void TryMatchFail()
    {
        ValueVariant<int, string, double> v;
        v = "10";
        var test = v.TryMatch((int i) => i * 10, out var result);
        Assert.AreEqual(false, test);
    }


    [Test]
    public void ReferenceTypes()
    {
        ValueVariant<object, string, TestExampleRef> v;
        var refT = new TestExampleRef();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleRef>());
    }

    [Test]
    public void ReferenceTypesEquality()
    {
        ValueVariant<object, string, TestExampleEqual> v;
        v = new TestExampleEqual(10);
        Assert.AreEqual(new TestExampleEqual(10), v.Get<TestExampleEqual>());
    }

    [Test]
    public void ValueNotSet()
    {
        var v = new ValueVariant<object, string, TestExampleEqual>();
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleEqual>());
    }
    
    [Test]
    public void CheckIfSet()
    {
        var v = new ValueVariant<object, string, TestExampleEqual>();
        Assert.False(v.IsSet());
        
        v = "test";
        Assert.True(v.IsSet());
    }
    
    [Test]
    public void TestToString()
    {
        ValueVariant<object, string, TestExampleEqual> v = "test";
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