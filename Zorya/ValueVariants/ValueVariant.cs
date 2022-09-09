namespace Zorya.ValueVariants;

internal enum SetItems : byte
{
    None,
    Item1,
    Item2,
    Item3,
    Item4,
    Item5,
    Item6,
    Item7,
    Item8
}

public static class ValueVariant
{
    internal static bool TestItem<TItem, TValue>(TItem item, bool isCorrectItem, out TValue? value)
    {
        if (item is TValue v && isCorrectItem)
        {
            value = v;
            return true;
        }

        value = default;
        return false;
    }
    
    public static T Get<T>(ValueVariant<T> variant)
    {
        return variant.Get<T>();
    }

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static bool TryGet<T>(ValueVariant<T> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

}