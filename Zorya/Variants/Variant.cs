namespace Zorya.Variants;

public abstract class Variant : IVariant
{
    protected SetItems SetItem = SetItems.None;

    public abstract bool Set<T>(T value);
    
    public abstract T Get<T>();
    public abstract bool TryGet<T>(out T? value);

    public abstract Type? GetSetType();

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

    protected bool TestItem<TItem, TValue>(TItem item, SetItems setItem, out TValue? value)
    {
        if (item is TValue v && SetItem == setItem)
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