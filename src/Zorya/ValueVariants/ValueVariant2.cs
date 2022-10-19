using System.Runtime.CompilerServices;

namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1, T2> : IValueVariant
{
    public ValueVariant(T1 item1)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
        Unsafe.SkipInit(out _item2);
    }

    public ValueVariant(T2 item2)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
        Unsafe.SkipInit(out _item1);
    }

    public static implicit operator ValueVariant<T1, T2>(T1 value)
    {
        return new ValueVariant<T1, T2>(value);
    }

    public static implicit operator ValueVariant<T1, T2>(T2 value)
    {
        return new ValueVariant<T1, T2>(value);
    }

    private readonly SetItems _setItem = SetItems.None;
    private readonly T1? _item1;

    private readonly T2? _item2;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(ValueVariant<T1, T2> variant)
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
    public static bool TryGet<T>(ValueVariant<T1, T2> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadValueVariantAccessException(typeof(T), this),
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public bool TryGet<T>(out T? value)
    {
        if (ValueVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        return ValueVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value);
    }
    
    /// <inheritdoc />
    public bool IsSet() => GetSetType() != null;
    
    /// <summary>
    /// Returns set type.
    /// </summary>
    /// <returns></returns>
    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => _item1.GetType(),
            SetItems.Item2 when _item2 is not null => _item2.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2)
    {
        if (_setItem == SetItems.Item1) action1(_item1!);
        if (_setItem == SetItems.Item2) action2(_item2!);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2)
    {
        return _setItem switch
        {
            SetItems.Item1 => func1(_item1!),
            SetItems.Item2 => func2(_item2!),
            _ => default
        };
    }

    /// <summary>
    ///     Matches set element with a given action. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="BadValueVariantAccessException"></exception>
    public void Match<T>(Action<T> action)
    {
        if (TryGet(out T? value))
            action(value!);
        else
            throw new BadValueVariantAccessException(typeof(T), this);
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
    ///     Matches set element with a given function. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <exception cref="BadValueVariantAccessException"></exception>
    public TResult Match<T, TResult>(Func<T, TResult> func)
    {
        if (TryGet(out T? value)) return func(value!);

        throw new BadValueVariantAccessException(typeof(T), this);
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

    public override string ToString()
    {
        return _setItem switch
        {
            SetItems.Item1 => _item1!.ToString(),
            SetItems.Item2 => _item2!.ToString(),
            _ => string.Empty
        } ?? string.Empty;
    }
}