﻿using System.Runtime.CompilerServices;

namespace Zorya.StructVariants;

public readonly struct StructVariant<T1, T2> : IStructVariant
{
    public StructVariant(T1 item1)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
        Unsafe.SkipInit(out _item2);
    }

    public StructVariant(T2 item2)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
        Unsafe.SkipInit(out _item1);
    }

    public static implicit operator StructVariant<T1, T2>(T1 value)
    {
        return new StructVariant<T1, T2>(value);
    }

    public static implicit operator StructVariant<T1, T2>(T2 value)
    {
        return new StructVariant<T1, T2>(value);
    }

    private readonly SetItems _setItem = SetItems.None;
    private readonly T1? _item1;

    private readonly T2? _item2;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadStructVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(StructVariant<T1, T2> variant)
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
    public static bool TryGet<T>(StructVariant<T1, T2> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadStructVariantAccessException(typeof(T), this),
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            _ => throw new BadStructVariantAccessException(typeof(T), this)
        };
    }

    public bool TryGet<T>(out T? value)
    {
        if (StructVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        return StructVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value);
    }


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
}