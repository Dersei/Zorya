namespace Zorya.ValueVariants;

public static class ValueVariantMarshall
{

    public static T1? GetValueUnsafe<T1>(in ValueVariant<T1> variant)
    {
        return variant.GetUnsafe();
    }
    
    public static object? GetValueUnsafe<T1, T2>(in ValueVariant<T1, T2> variant)
    {
        return variant.GetUnsafe();
    }

    public static object? GetValueUnsafe<T1, T2, T3>(in ValueVariant<T1, T2, T3> variant)
    {
        return variant.GetUnsafe();
    }

    public static object? GetValueUnsafe<T1, T2, T3, T4>(in ValueVariant<T1, T2, T3, T4> variant)
    {
        return variant.GetUnsafe();
    }

    public static object? GetValueUnsafe<T1, T2, T3, T4, T5>(in ValueVariant<T1, T2, T3, T4, T5> variant)
    {
        return variant.GetUnsafe();
    }

    public static object? GetValueUnsafe<T1, T2, T3, T4, T5, T6>(in ValueVariant<T1, T2, T3, T4, T5, T6> variant)
    {
        return variant.GetUnsafe();
    }

    public static object? GetValueUnsafe<T1, T2, T3, T4, T5, T6, T7>(in ValueVariant<T1, T2, T3, T4, T5, T6, T7> variant)
    {
        return variant.GetUnsafe();
    }

    public static object? GetValueUnsafe<T1, T2, T3, T4, T5, T6, T7, T8>(in ValueVariant<T1, T2, T3, T4, T5, T6, T7, T8> variant)
    {
        return variant.GetUnsafe();
    }
}