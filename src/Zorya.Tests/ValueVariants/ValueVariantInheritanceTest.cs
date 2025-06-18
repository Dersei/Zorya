using NUnit.Framework;
using Zorya.ValueVariants;

namespace Zorya.Tests.ValueVariants;

public class ValueVariantInheritanceTest
{
[Test]
    public void ParentEquality()
    {
        ValueVariant<object, string, TestExampleParent> v;
        var refT = new TestExampleParent();
        v = refT;
        ClassicAssert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void GetParentWithChildSetInParent()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        ClassicAssert.AreEqual(refT, v.Get<TestExampleParent>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParent()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParentTestType()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        ClassicAssert.AreEqual(typeof(TestExampleParent), v.GetSetType());
    }

    [Test] //?
    public void GetParentWithChildSetInChild()
    {
        ValueVariant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleParent>());
    }

    [Test]
    public void GetChildWithChildSetInBothParentAndChild()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    [Test]
    public void GetChildWithChildSetInBothChildAndParent()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }
    
    [Test]
    public void GetObject()
    {
        var v =  new ValueVariant<int, decimal, char, byte, object, long, string, bool>("true");
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<object>());
    }
    
    [Test]
    public void GetChildWithParentSetInBothParentAndChild()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleParent { Id = 10 };
        v = refT;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleChild>());
    }

    [Test]
    public void GetChildWithParentSetInBothChildAndParent()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleParent { Id = 10 };
        v = refT;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetParentWithChildSetInBothParentAndChild()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleParent>());
    }

    [Test] //?
    public void GetParentWithChildSetInBothChildAndParent()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleParent>());
    }
    
    [Test]
    public void IsSet()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.AreEqual(true, v.IsSet<TestExampleChild>());
        ClassicAssert.AreEqual(false, v.IsSet<TestExampleParent>());
    }
    
    [Test]
    public void IsSetParent()
    {
        ValueVariant<int, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.AreEqual(false, v.IsSet<TestExampleChild>());
        ClassicAssert.AreEqual(true, v.IsSet<TestExampleParent>());
    }

    [Test]
    public void TryGet()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.AreEqual(true, v.TryGet<TestExampleChild>(out _));
        ClassicAssert.AreEqual(false, v.TryGet<TestExampleParent>(out _));
    }
    
    [Test]
    public void TryGetParent()
    {
        ValueVariant<int, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        ClassicAssert.AreEqual(true, v.TryGet<TestExampleParent>(out _));
        ClassicAssert.AreEqual(false, v.TryGet<TestExampleChild>(out _));
    }

    private class TestExampleParent
    {
        public int Id { get; init; }
    }

    private class TestExampleChild : TestExampleParent
    {
    }
}