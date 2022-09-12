namespace Zorya.Variants;

public class BadVariantAccessException : Exception
{
    public BadVariantAccessException() : base(
        "Bad variant access")
    {
    }

    public BadVariantAccessException(Type expected, IVariant variant) : base(
        $"Bad variant access, expected: {expected}, but the set type is {variant.GetSetType()?.ToString() ?? "None"}")
    {
    }

    public BadVariantAccessException(string message)
        : base(message)
    {
    }

    public BadVariantAccessException(string message, Exception inner)
        : base(message, inner)
    {
    }
}