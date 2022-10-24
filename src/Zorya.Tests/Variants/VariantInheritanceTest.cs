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
        Assert.Throws<BadVariantAccessException>(() => v.Get<TestExampleChild>());
    }
    
    [Test] //?
    public void GetChildWithChildSetInParentTestType()
    {
        Variant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(typeof(TestExampleParent), v.GetSetType());
    }

    [Test] //?
    public void GetParentWithChildSetInChild()
    {
        Variant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.Throws<BadVariantAccessException>(() => v.Get<TestExampleParent>());
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
    public void GetObject()
    {
        var v =  new Variant<int, decimal, char, byte, object, long, string, bool>("true");;
        Assert.Throws<BadVariantAccessException>(() => v.Get<object>());
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
        Assert.Throws<BadVariantAccessException>(() => v.Get<TestExampleParent>());
    }

    [Test] //?
    public void GetParentWithChildSetInBothChildAndParent()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.Throws<BadVariantAccessException>(() => v.Get<TestExampleParent>());
    }
    
    [Test]
    public void IsSet()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(true, v.IsSet<TestExampleChild>());
        Assert.AreEqual(false, v.IsSet<TestExampleParent>());
    }
    
    [Test]
    public void IsSetParent()
    {
        Variant<int, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(false, v.IsSet<TestExampleChild>());
        Assert.AreEqual(true, v.IsSet<TestExampleParent>());
    }
    
    [Test]
    public void TryGet()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(true, v.TryGet<TestExampleChild>(out _));
        Assert.AreEqual(false, v.TryGet<TestExampleParent>(out _));
    }
    
    [Test]
    public void TryGetParent()
    {
        Variant<int, TestExampleParent> v;
        var refT = new TestExampleChild { Id = 10 };
        v = refT;
        Assert.AreEqual(true, v.TryGet<TestExampleParent>(out _));
        Assert.AreEqual(false, v.TryGet<TestExampleChild>(out _));
    }


    private class TestExampleParent
    {
        public int Id { get; init; }
    }

    private class TestExampleChild : TestExampleParent
    {
    }
}