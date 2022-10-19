namespace Zorya.ValueVariants;

/// <summary>
/// The exception that is thrown if there is no type set in the variant.
/// </summary>
public class BadValueVariantAccessException : Exception
{
    internal BadValueVariantAccessException() : base(
        "Bad variant access")
    {
    }

    internal BadValueVariantAccessException(Type expected, IValueVariant variant) : base(
        $"Bad variant access, expected: {expected}, but the set type is {variant.GetSetType()?.ToString() ?? "None"}")
    {
    }

    internal BadValueVariantAccessException(string message)
        : base(message)
    {
    }

    internal BadValueVariantAccessException(string message, Exception inner)
        : base(message, inner)
    {
    }
}