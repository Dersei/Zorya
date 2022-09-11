﻿using System.Runtime.CompilerServices;

namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1, T2, T3> : IValueVariant
{
    private ValueVariant(bool _)
    {
        Unsafe.SkipInit(out _item1);
        Unsafe.SkipInit(out _item2);
        Unsafe.SkipInit(out _item3);
    }

    public ValueVariant(T1 item1) : this(true)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public ValueVariant(T2 item2) : this(true)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    public ValueVariant(T3 item3) : this(true)
    {
        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public static implicit operator ValueVariant<T1, T2, T3>(T1 value)
    {
        return new ValueVariant<T1, T2, T3>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3>(T2 value)
    {
        return new ValueVariant<T1, T2, T3>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3>(T3 value)
    {
        return new ValueVariant<T1, T2, T3>(value);
    }

    private readonly SetItems _setItem = SetItems.None;

    private readonly T1? _item1;

    private readonly T2? _item2;
    private readonly T3? _item3;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(ValueVariant<T1, T2, T3> variant)
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
    public static bool TryGet<T>(ValueVariant<T1, T2, T3> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadValueVariantAccessException(typeof(T), this),
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            SetItems.Item3 when _item3 is T t3 => t3,
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    public bool TryGet<T>(out T? value)
    {
        if (ValueVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value)) return true;
        return ValueVariant.TestItem(_item3, SetItems.Item3 == _setItem, out value);
    }


    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => _item1.GetType(),
            SetItems.Item2 when _item2 is not null => _item2.GetType(),
            SetItems.Item3 when _item3 is not null => _item3.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    /// <summary>
    /// Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3)
    {
        if (_setItem == SetItems.Item1) action1(_item1!);
        if (_setItem == SetItems.Item2) action2(_item2!);
        if (_setItem == SetItems.Item3) action3(_item3!);
    }
    /// <summary>
    /// Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3)
    {
        return _setItem switch
        {
            SetItems.Item1 => func1(_item1!),
            SetItems.Item2 => func2(_item2!),
            SetItems.Item3 => func3(_item3!),
            _ => default
        };
    }
}