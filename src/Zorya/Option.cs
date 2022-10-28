using System.Diagnostics.CodeAnalysis;

namespace Zorya;

public readonly struct Option<T> where T : notnull
{
    private readonly T _value;
    private readonly bool _isSome;

    private Option(T value)
    {
        _value = value;
        _isSome = true;
    }

    public bool IsSome([MaybeNullWhen(false)] out T value)
    {
        value = _value;
        return _isSome;
    }

    public static Option<T> None => default;

    public static Option<T> Some(T value)
    {
        if (value is null) return None;
        return new(value);
    }
}

public static class Option
{
    public static TValue Match<T, TValue>(this Option<T> option, Func<T, TValue> onSome, Func<TValue> onNone)
        where T : notnull
    {
        return option.IsSome(out var value) ? onSome(value) : onNone();
    }

    public static Option<TValue> Bind<T, TValue>(this Option<T> option, Func<T, Option<TValue>> binder)
        where T : notnull where TValue : notnull
    {
        return option.Match(onSome: binder, onNone: () => Option<TValue>.None);
    }

    public static Option<TValue> Map<T, TValue>(this Option<T> option, Func<T, TValue> mapper)
        where T : notnull where TValue : notnull
    {
        return option.Bind(value => Option<TValue>.Some(mapper(value)));
    }

    public static Option<T> Filter<T>(this Option<T> option, Predicate<T> predicate)
        where T : notnull
    {
        return option.Bind(value => predicate(value) ? option : Option<T>.None);
    }

    public static T DefaultValue<T>(this Option<T> option, T defaultValue)
        where T : notnull
    {
        return option.Match(onSome: value => value, onNone: () => defaultValue);
    }
}