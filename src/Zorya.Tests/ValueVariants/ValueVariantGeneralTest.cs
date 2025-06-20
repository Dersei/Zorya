﻿using System;
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
        ClassicAssert.AreEqual(100, v.Match((int i) => i * 10));
        v = "10";
        ClassicAssert.AreEqual("1010", v.Match((string s) => s + 10));
    }

    [Test]
    public void MatchFail()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Match((string s) => s + 10));
    }

    [Test]
    public void MatchOrDefault()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        ClassicAssert.AreEqual(100, v.MatchOrDefault((int i) => i * 10, 11));
        v = "10";
        ClassicAssert.AreEqual("1010", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void MatchOrDefaultFail()
    {
        ValueVariant<int, string, double> v;
        v = "10";
        ClassicAssert.AreEqual(11, v.MatchOrDefault((int i) => i * 10, 11));
        v = 10;
        ClassicAssert.AreEqual("1000", v.MatchOrDefault((string s) => s + 10, "1000"));
    }

    [Test]
    public void TryMatch()
    {
        ValueVariant<int, string, double> v;
        v = 10;
        var test = v.TryMatch((int i) => i * 10, out var result);
        ClassicAssert.AreEqual(true, test);
        ClassicAssert.AreEqual(100, result);
    }

    [Test]
    public void TryMatchFail()
    {
        ValueVariant<int, string, double> v;
        v = "10";
        var test = v.TryMatch((int i) => i * 10, out _);
        ClassicAssert.AreEqual(false, test);
    }


    [Test]
    public void ReferenceTypes()
    {
        ValueVariant<object, string, TestExampleRef> v;
        var refT = new TestExampleRef();
        v = refT;
        ClassicAssert.AreEqual(refT, v.Get<TestExampleRef>());
    }

    [Test]
    public void ReferenceTypesEquality()
    {
        ValueVariant<object, string, TestExampleEqual> v;
        v = new TestExampleEqual(10);
        ClassicAssert.AreEqual(new TestExampleEqual(10), v.Get<TestExampleEqual>());
    }

    [Test]
    public void ValueNotSet()
    {
        var v = new ValueVariant<object, string, TestExampleEqual>();
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleEqual>());
    }
    
    [Test]
    public void CheckIfValid()
    {
        var v = new ValueVariant<object, string, TestExampleEqual>();
        ClassicAssert.False(v.IsValid());
        
        v = "test";
        ClassicAssert.True(v.IsValid());
        
        var v1 = new ValueVariant<object, string>(null!);
        ClassicAssert.False(v1.IsValid());
        
        ValueVariant<int, TestExampleEqual> v2 = null!;
        ClassicAssert.False(v2.IsValid());
        
        ValueVariant<int, TestExampleEqual> v3 = 1;
        ClassicAssert.True(v3.IsValid());

        v3 = null!;
        ClassicAssert.False(v3.IsValid());
    }
    
    [Test]
    public void TestInvalidCases()
    {
        ValueVariant<int, string, double, long, float, byte, char> v = new(null!);
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<string>());
        ClassicAssert.AreEqual(null, v.GetSetType());
        ClassicAssert.False(v.TryGet(out string? _));
        ClassicAssert.AreEqual(0, v.Visit(_ => 1, _ => 2, _ => 3, _ => 4, _ => 5, _ => 6, _ => 7));
        ValueVariant<int, string> v1 = new(null!);
        ValueVariant<int, string> v2 = new(null!);
        ClassicAssert.AreEqual(v1, v2);
        ClassicAssert.False(v.IsSet<string>());
    }
    
    [Test]
    public void TestToString()
    {
        ValueVariant<object, string, TestExampleEqual> v = "test";
        ClassicAssert.True(v.ToString().Contains("test"));
        v = new TestExampleEqual(10);
        ClassicAssert.True(v.ToString().Contains(nameof(TestExampleEqual)));
        ClassicAssert.False(v.ToString().Contains("test"));
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