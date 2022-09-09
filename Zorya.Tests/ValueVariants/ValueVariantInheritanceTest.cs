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
    public void ParentInChildGet()
    {
        ValueVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ChildInParentGet()
    {
        ValueVariant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ChildInParentInChildGet()
    {
        ValueVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild {Id = 10};
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    [Test]
    public void ParentInChildInChildGet()
    {
        ValueVariant<int, TestExampleChild, TestExampleParent> v;
        var refT = new TestExampleChild {Id = 10};
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    private class TestExampleParent
    {
        public int Id { get; init; }
    }

    private class TestExampleChild : TestExampleParent
    {
    }
}