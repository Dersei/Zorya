using NUnit.Framework;
using Zorya.StructVariants;

namespace Zorya.Tests.StructVariants;

public class StructVariantInheritanceTest
{
    [Test]
    public void ParentEquality()
    {
        StructVariant<object, string, TestExampleParent> v;
        var refT = new TestExampleParent();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ParentInChildGet()
    {
        StructVariant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ChildInParentGet()
    {
        StructVariant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ChildInParentInChildGet()
    {
        StructVariant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild {Id = 10};
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    [Test]
    public void ParentInChildInChildGet()
    {
        StructVariant<int, TestExampleChild, TestExampleParent> v;
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