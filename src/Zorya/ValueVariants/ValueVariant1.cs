using System.Runtime.CompilerServices;

namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1> : IValueVariant,
    IEquatable<ValueVariant<T1>>
{
    public ValueVariant(T1 item)
    {
        _item = item;
        _setItem = SetItems.Item1;
    }

    public static implicit operator ValueVariant<T1>(T1 value)
    {
        if (value is null) return default;
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

    /// <inheritdoc />
    public bool IsSet<T>() => _setItem != SetItems.None && TryGet(out T? _);

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadValueVariantAccessException(typeof(T), this),
            SetItems.Item1 when typeof(T) == typeof(T1) && _item is T t1 => t1,
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGet<T>(out T? value)
    {
        return ValueVariant.TestItem(_item, _setItem == SetItems.Item1, out value);
    }

    /// <inheritdoc />
    public bool IsValid() => _setItem != SetItems.None && GetSetType() is not null;

    /// <summary>
    /// Returns set type.
    /// </summary>
    /// <returns></returns>
    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item is not null => typeof(T1),
            _ => null
        };
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    /// <param name="action"></param>
    public void Visit(Action<T1> action)
    {
        if (_setItem == SetItems.Item1 && _item is not null) action(_item);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func)
    {
        if (_setItem == SetItems.Item1 && _item is not null) return func(_item!);
        return default;
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
        return _item?.ToString() ?? string.Empty;
    }

    public bool Equals(ValueVariant<T1> other)
    {
        return _setItem == other._setItem
               && _setItem switch
               {
                   SetItems.None => true,
                   SetItems.Item1 => EqualityComparer<T1?>.Default.Equals(_item, other._item),
                   _ => false
               };
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueVariant<T1> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)_setItem, _item);
    }

    public static bool operator ==(ValueVariant<T1> left, ValueVariant<T1> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValueVariant<T1> left, ValueVariant<T1> right)
    {
        return !left.Equals(right);
    }
}