namespace Zorya.Variants;

/// <summary>
/// The exception that is thrown if there is no type set in the variant.
/// </summary>
public class BadVariantAccessException : Exception
{
    internal BadVariantAccessException() : base(
        "Bad variant access")
    {
    }

    internal BadVariantAccessException(Type expected, IVariant variant) : base(
        $"Bad variant access, expected: {expected}, but the set type is {variant.GetSetType()?.ToString() ?? "None"}")
    {
    }

    internal BadVariantAccessException(string message)
        : base(message)
    {
    }

    internal BadVariantAccessException(string message, Exception inner)
        : base(message, inner)
    {
    }
}