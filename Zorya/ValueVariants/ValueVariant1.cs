namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1> : IValueVariant
{
    public ValueVariant(T1 item)
    {
        _item = item;
        _setItem = SetItems.Item1;
    }

    public static implicit operator ValueVariant<T1>(T1 value)
    {
        return new ValueVariant<T1>(value);
    }

    private readonly SetItems _setItem = SetItems.None;

    private readonly T1? _item;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
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

    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadValueVariantAccessException(typeof(T), this),
            SetItems.Item1 when _item is T t => t,
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    public bool TryGet<T>(out T? value)
    {
        return ValueVariant.TestItem(_item, _setItem == SetItems.Item1, out value);
    }


    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item is not null => _item.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}