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
    
    /// <summary>
    /// Allows to use a delegate on set item.
    /// </summary>
    /// <param name="action"></param>
    public void Visit(Action<T1> action)
    {
        if (_setItem == SetItems.Item1) action(_item!);
    }
    
    /// <summary>
    /// Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func)
    {
        if (_setItem == SetItems.Item1) return func(_item!);
        return default;
    }
}