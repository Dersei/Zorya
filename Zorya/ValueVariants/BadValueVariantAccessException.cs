namespace Zorya.ValueVariants;

public class BadValueVariantAccessException : Exception
{
    public BadValueVariantAccessException() : base(
        "Bad variant access")
    {
    }

    public BadValueVariantAccessException(Type expected, IValueVariant variant) : base(
        $"Bad variant access, expected: {expected}, but the set type is {variant.GetSetType()?.ToString() ?? "None"}")
    {
    }

    public BadValueVariantAccessException(string message)
        : base(message)
    {
    }

    public BadValueVariantAccessException(string message, Exception inner)
        : base(message, inner)
    {
    }
}