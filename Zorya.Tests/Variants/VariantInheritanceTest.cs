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
    public void ParentInChildGet()
    {
        Variant<int, string, TestExampleParent> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ChildInParentGet()
    {
        Variant<int, string, TestExampleChild> v;
        var refT = new TestExampleChild();
        v = refT;
        Assert.AreEqual(refT, v.Get<TestExampleParent>());
    }

    [Test]
    public void ChildInParentInChildGet()
    {
        Variant<int, TestExampleParent, TestExampleChild> v;
        var refT = new TestExampleChild {Id = 10};
        v = refT;
        Assert.AreEqual(10, v.Get<TestExampleChild>().Id);
    }

    [Test]
    public void ParentInChildInChildGet()
    {
        Variant<int, TestExampleChild, TestExampleParent> v;
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