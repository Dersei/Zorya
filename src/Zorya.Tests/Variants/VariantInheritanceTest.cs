using NUnit.Framework;
using Zorya.Variants;

namespace Zorya.Tests.Variants;

public class VariantInheritanceTest
{
    [Test]
    public void ParentEquality()
    {
        Variant<object, string, TestExampleParent> v;
        var refT = new TestExampleParent();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void GetParentWithChildSetInParent()
    {
        Variant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParent()
    {
        Variant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParentTestType()
    {
        Variant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(typeof(TestExampleChild), v.GetSetType());
    }

    [Test] //?
    public void GetParentWithChildSetInChild()
    {
        Variant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void GetChildWithChildSetInBothParentAndChild()
    {
        Variant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    [Test]
    public void GetChildWithChildSetInBothChildAndParent()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }
    
    [Test]
    public void GetChildWithParentSetInBothParentAndChild()
    {
        Variant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleParent { Id = 10 };
        v = refT;
        Assert.Throws<BadVariantAccessException>(() => v.Get<TestExampleChild>());
    }

    [Test]
    public void GetChildWithParentSetInBothChildAndParent()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleParent { Id = 10 };
        v = refT;
        Assert.Throws<BadVariantAccessException>(() => v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetParentWithChildSetInBothParentAndChild()
    {
        Variant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleParent>().Id);
    }

    [Test] //?
    public void GetParentWithChildSetInBothChildAndParent()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleParent>().Id);
    }


    private class TestExampleParent
    {
        public int Id { get; init; }
    }

    private class TestExampleChild : TestExampleParent
    {
    }
}