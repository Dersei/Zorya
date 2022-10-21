namespace Zorya.Variants;

public abstract class Variant : IVariant
{
    protected SetItems SetItem = SetItems.None;

    /// <summary>
    /// Sets a value to the given type without creating a new object.
    /// </summary>
    /// <param name="value">Value to set.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public abstract bool Set<T>(T value);

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public abstract T Get<T>();

    public bool IsSet<T>() => SetItem != SetItems.None && TryGet(out T? _);

    /// <summary>
    ///     Gets a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public abstract bool TryGet<T>(out T? value);

    /// <summary>
    /// Returns set type.
    /// </summary>
    /// <returns></returns>
    public abstract Type? GetSetType();

    /// <summary>
    ///     Matches set element with a given action. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="BadVariantAccessException"></exception>
    public void Match<T>(Action<T> action)
    {
        if (TryGet(out T? value))
            action(value!);
        else
            throw new BadVariantAccessException(typeof(T), this);
    }

    /// <summary>
    ///     Matches set element with a given action. Executes fallback function if there's no matching type.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="fallback">Fallback action, executed if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    public void MatchOrDefault<T>(Action<T> action, Action fallback)
    {
        if (TryGet(out T? value))
            action(value!);
        else
            fallback();
    }

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public bool TryMatch<T>(Action<T> action)
    {
        if (TryGet(out T? value))
        {
            action(value!);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Matches set element with a given function. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <exception cref="BadVariantAccessException"></exception>
    public TResult Match<T, TResult>(Func<T, TResult> func)
    {
        if (TryGet(out T? value)) return func(value!);

        throw new BadVariantAccessException(typeof(T), this);
    }

    /// <summary>
    ///     Matches set element with a given function. Returns default value if there's no matching type.
    /// </summary>
    /// <param name="func"></param>
    /// <param name="default">Default value to return if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public TResult MatchOrDefault<T, TResult>(Func<T, TResult> func, TResult @default)
    {
        if (TryGet(out T? value)) return func(value!);

        return @default;
    }

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <param name="result">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public bool TryMatch<T, TResult>(Func<T, TResult> func, out TResult? result)
    {
        if (TryGet(out T? value))
        {
            result = func(value!);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(IVariant variant)
    {
        return variant.Get<T>();
    }

    /// <summary>
    ///     Gets a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static bool TryGet<T>(IVariant variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Matches set element with a given action. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="BadVariantAccessException"></exception>
    public static void Match<T>(IVariant variant, Action<T> action)
    {
        if (variant.TryGet(out T? value))
            action(value!);
        else
            throw new BadVariantAccessException(typeof(T), variant);
    }

    /// <summary>
    ///     Matches set element with a given action. Executes fallback function if there's no matching type.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="action"></param>
    /// <param name="fallback">Fallback action, executed if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    public static void MatchOrDefault<T>(IVariant variant, Action<T> action, Action fallback)
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
    public static bool TryMatch<T>(IVariant variant, Action<T> action)
    {
        if (variant.TryGet(out T? value))
        {
            action(value!);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Matches set element with a given function. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <exception cref="BadVariantAccessException"></exception>
    public static TResult Match<T, TResult>(IVariant variant, Func<T, TResult> func)
    {
        if (variant.TryGet(out T? value)) return func(value!);

        throw new BadVariantAccessException(typeof(T), variant);
    }

    /// <summary>
    ///     Matches set element with a given function. Returns default value if there's no matching type.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="func"></param>
    /// <param name="default">Default value to return if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public static TResult MatchOrDefault<T, TResult>(IVariant variant, Func<T, TResult> func, TResult @default)
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
    public static bool TryMatch<T, TResult>(IVariant variant, Func<T, TResult> func, out TResult? result)
    {
        if (variant.TryGet(out T? value))
        {
            result = func(value!);
            return true;
        }

        result = default;
        return false;
    }

    protected bool TestItem<TItem, TValue>(TItem item, SetItems setItem, out TValue? value)
    {
        if (SetItem == setItem && item is TValue v)
        {
            value = v;
            return true;
        }

        value = default;
        return false;
    }

    protected bool SetItemInternal<TItem, TValue>(ref TItem item, SetItems setItem, TValue? value)
    {
        if (value is TItem v)
        {
            SetItem = setItem switch
            {
                SetItems.Item1 => SetItems.Item1,
                SetItems.Item2 => SetItems.Item2,
                SetItems.Item3 => SetItems.Item3,
                SetItems.Item4 => SetItems.Item4,
                SetItems.Item5 => SetItems.Item5,
                SetItems.Item6 => SetItems.Item6,
                SetItems.Item7 => SetItems.Item7,
                SetItems.Item8 => SetItems.Item8,
                _ => throw new ArgumentOutOfRangeException(nameof(setItem), setItem, null)
            };
            item = v;
            return true;
        }

        return false;
    }

    protected enum SetItems : byte
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
}