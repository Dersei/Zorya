namespace Zorya.Variants;

public static class VariantMarshall
{
    public static object? GetValueUnsafe(Variant variant)
    {
        return variant.GetUnsafe();
    }
}