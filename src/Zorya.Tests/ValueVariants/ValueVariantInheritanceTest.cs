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
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void GetParentWithChildSetInParent()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParent()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParentTestType()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(typeof(TestExampleParent), v.GetSetType());
    }

    [Test] //?
    public void GetParentWithChildSetInChild()
    {
        ValueVariant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleParent>());
    }

    [Test]
    public void GetChildWithChildSetInBothParentAndChild()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    [Test]
    public void GetChildWithChildSetInBothChildAndParent()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }
    
    [Test]
    public void GetObject()
    {
        var v =  new ValueVariant<int, decimal, char, byte, object, long, string, bool>("true");;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<object>());
    }
    
    [Test]
    public void GetChildWithParentSetInBothParentAndChild()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleParent { Id = 10 };
        v = refT;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleChild>());
    }

    [Test]
    public void GetChildWithParentSetInBothChildAndParent()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleParent { Id = 10 };
        v = refT;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetParentWithChildSetInBothParentAndChild()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleParent>());
    }

    [Test] //?
    public void GetParentWithChildSetInBothChildAndParent()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.Throws<BadValueVariantAccessException>(() => v.Get<TestExampleParent>());
    }


    private class TestExampleParent
    {
        public int Id { get; init; }
    }

    private class TestExampleChild : TestExampleParent
    {
    }
}