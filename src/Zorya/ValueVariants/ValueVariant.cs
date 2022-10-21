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
        if (isCorrectItem && item is TValue v)
        {
            value = v;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(IValueVariant variant)
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
    public static bool TryGet<T>(IValueVariant variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Matches set element with a given action. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="BadValueVariantAccessException"></exception>
    public static void Match<T>(IValueVariant variant, Action<T> action)
    {
        if (variant.TryGet(out T? value))
            action(value!);
        else
            throw new BadValueVariantAccessException(typeof(T), variant);
    }

    /// <summary>
    ///     Matches set element with a given action. Executes fallback function if there's no matching type.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="action"></param>
    /// <param name="fallback">Fallback action, executed if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    public static void MatchOrDefault<T>(IValueVariant variant, Action<T> action, Action fallback)
    {
        if (variant.TryGet(out T? value))
            action(value!);
        else
            fallback();
    }

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="action"></param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static bool TryMatch<T>(IValueVariant variant, Action<T> action)
    {
        if (variant.TryGet(out T? value))
        {
            action(value!);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Matches set element with a given function. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <exception cref="BadValueVariantAccessException"></exception>
    public static TResult Match<T, TResult>(IValueVariant variant, Func<T, TResult> func)
    {
        if (variant.TryGet(out T? value)) return func(value!);

        throw new BadValueVariantAccessException(typeof(T), variant);
    }

    /// <summary>
    ///     Matches set element with a given function. Returns default value if there's no matching type.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="func"></param>
    /// <param name="default">Default value to return if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public static TResult MatchOrDefault<T, TResult>(IValueVariant variant, Func<T, TResult> func, TResult @default)
    {
        if (variant.TryGet(out T? value)) return func(value!);

        return @default;
    }

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="func"></param>
    /// <param name="result">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static bool TryMatch<T, TResult>(IValueVariant variant, Func<T, TResult> func, out TResult? result)
    {
        if (variant.TryGet(out T? value))
        {
            result = func(value!);
            return true;
        }

        result = default;
        return false;
    }
}