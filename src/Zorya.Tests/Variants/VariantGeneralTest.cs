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
        ClassicAssert.AreEqual(100, v.Match((int i) => i * 10));
        v = "10";
        ClassicAssert.AreEqual("1010", v.Match((string s) => s + 10));
    }

    [Test]
    public void SetValue()
    {
        Variant<int, string> v = new(10);
        var test = v.Set((string)null!);
        ClassicAssert.IsFalse(test);
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
        ClassicAssert.AreEqual(100, v.MatchOrDefault((int i) => i * 10, 11));
        v = "10";
        ClassicAssert.AreEqual("1010", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void MatchOrDefaultFail()
    {
        Variant<int, string, double> v;
        v = "10";
        ClassicAssert.AreEqual(11, v.MatchOrDefault((int i) => i * 10, 11));
        v = 10;
        ClassicAssert.AreEqual("1000", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void TryMatch()
    {
        Variant<int, string, double> v;
        v = 10;
        var test = v.TryMatch((int i) => i * 10, out var result);
        ClassicAssert.AreEqual(true, test);
        ClassicAssert.AreEqual(100, result);
    }

    [Test]
    public void TryMatchFail()
    {
        Variant<int, string, double> v;
        v = "10";
        var test = v.TryMatch((int i) => i * 10, out _);
        ClassicAssert.AreEqual(false, test);
    }

    [Test]
    public void ReferenceTypes()
    {
        Variant<object, string, TestExampleRef> v;
        var refT = new TestExampleRef();
        v = refT;
        ClassicAssert.AreEqual(refT, v.Get<TestExampleRef>());
    }

    [Test]
    public void ReferenceTypesEquality()
    {
        Variant<object, string, TestExampleEqual> v;
        v = new TestExampleEqual(10);
        ClassicAssert.AreEqual(new TestExampleEqual(10), v.Get<TestExampleEqual>());
    }
    
    [Test]
    public void TestToString()
    {
        Variant<object, string, TestExampleEqual> v = "test";
        ClassicAssert.True(v.ToString().Contains("test"));
        v = new TestExampleEqual(10);
        ClassicAssert.True(v.ToString().Contains(nameof(TestExampleEqual)));
        ClassicAssert.False(v.ToString().Contains("test"));
    }
    
    [Test]
    public void CheckIfValid()
    {
        var v = new Variant<object, string>(null!);
        ClassicAssert.False(v.IsValid());
        
        v = "test";
        ClassicAssert.True(v.IsValid());
        
        Variant<int, TestExampleEqual> v2 = null!;
        ClassicAssert.False(v2.IsValid());
        
        Variant<int, TestExampleEqual> v3 = 1;
        ClassicAssert.True(v3.IsValid());

        v3 = null!;
        ClassicAssert.False(v3.IsValid());
    }

    [Test]
    public void TestNullCases()
    {
        Variant<int, string, double, long, float, byte, char> v = new(null!);
        Assert.Throws<BadVariantAccessException>(() => v.Get<string>());
        ClassicAssert.AreEqual(null, v.GetSetType());
        ClassicAssert.False(v.TryGet(out string? _));
        ClassicAssert.AreEqual(0, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
        Variant<int, string> v1 = new(null!);
        Variant<int, string> v2 = new(null!);
        ClassicAssert.AreEqual(v1, v2);
        ClassicAssert.False(v.IsSet<string>());

        var value = 0;
        v.Visit(_ => value = 1, _ => value = 2, _ => value = 3, _ => value = 4, _ => value = 5, _ => value = 6,
            _ => value = 7);
        ClassicAssert.AreEqual(0, value);
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