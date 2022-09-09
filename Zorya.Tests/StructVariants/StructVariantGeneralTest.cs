﻿using System;
using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariantGeneralTest
{
    [Test]
    public void ReferenceTypes()
    {
        StructVariant<object, string, TestExampleRef> v;
        var refT = new TestExampleRef();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleRef>());
    }

    [Test]
    public void ReferenceTypesEquality()
    {
        StructVariant<object, string, TestExampleEqual> v;
        v = new TestExampleEqual(10);
        Assert.AreEqual(new TestExampleEqual(10), v.Get<TestExampleEqual>());
    }
    
    [Test]
    public void ValueNotSet()
    {
        StructVariant<object, string, TestExampleEqual> v = new StructVariant<object, string, TestExampleEqual>();
        Assert.Throws<BadStructVariantAccessException>(() =>v.Get<TestExampleEqual>());
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
            return Equals((TestExampleEqual) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}