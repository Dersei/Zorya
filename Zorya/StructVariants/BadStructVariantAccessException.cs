namespace Zorya.StructVariants;

public class BadStructVariantAccessException : Exception
{
    public BadStructVariantAccessException() : base(
        "Bad variant access")
    {
    }

    public BadStructVariantAccessException(Type expected, IStructVariant variant) : base(
        $"Bad variant access, expected: {expected}, but the set type is {variant.GetSetType()?.ToString() ?? "None"}")
    {
    }

    public BadStructVariantAccessException(string message)
        : base(message)
    {
    }

    public BadStructVariantAccessException(string message, Exception inner)
        : base(message, inner)
    {
    }
}