using NUnit.Framework;

namespace Zorya.Tests;

public class OptionTest
{
    [Test]
    public void CreateSome()
    {
        var option = Option<string>.Some("test");
        Assert.IsTrue(option.IsSome(out _));
    }
    
    [Test]
    public void CreateSomeWithNull()
    {
        var option = Option<string>.Some(null!);
        Assert.IsFalse(option.IsSome(out _));
    }
    
    [Test]
    public void CreateNone()
    {
        var option = Option<string>.None;
        Assert.IsFalse(option.IsSome(out _));
    }
}