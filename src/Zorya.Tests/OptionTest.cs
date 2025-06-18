using NUnit.Framework;

namespace Zorya.Tests;

public class OptionTest
{
    [Test]
    public void CreateSome()
    {
        var option = Option<string>.Some("test");
        ClassicAssert.IsTrue(option.IsSome(out _));
    }
    
    [Test]
    public void CreateSomeWithNull()
    {
        var option = Option<string>.Some(null!);
        ClassicAssert.IsFalse(option.IsSome(out _));
    }
    
    [Test]
    public void CreateNone()
    {
        var option = Option<string>.None;
        ClassicAssert.IsFalse(option.IsSome(out _));
    }
}