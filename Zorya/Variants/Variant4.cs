﻿using System.Diagnostics.CodeAnalysis;

namespace Zorya.Variants;

public class Variant<T1, T2, T3, T4> : Variant, IVariant
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;

    public Variant(T1 item1)
    {
        _item1 = item1;
        SetItem = SetItems.Item1;
    }

    public Variant(T2 item2)
    {
        _item2 = item2;
        SetItem = SetItems.Item2;
    }

    public Variant(T3 item3)
    {
        _item3 = item3;
        SetItem = SetItems.Item3;
    }

    public Variant(T4 item4)
    {
        _item4 = item4;
        SetItem = SetItems.Item4;
    }

    private T1? Item1 => _item1;

    private T2? Item2 => _item2;

    private T3? Item3 => _item3;

    private T4? Item4 => _item4;

    public override T Get<T>()
    {
        return SetItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T), this),
            SetItems.Item1 when Item1 is T t1 => t1,
            SetItems.Item2 when Item2 is T t2 => t2,
            SetItems.Item3 when Item3 is T t3 => t3,
            SetItems.Item4 when Item4 is T t4 => t4,
            _ => throw new BadVariantAccessException(typeof(T), this)
        };
    }

    public override bool TryGet<T>([MaybeNull] out T value)
    {
        if (TestItem(Item1, SetItems.Item1, out value)) return true;
        if (TestItem(Item2, SetItems.Item2, out value)) return true;
        if (TestItem(Item3, SetItems.Item3, out value)) return true;
        return TestItem(Item4, SetItems.Item4, out value);
    }

    public override Type? GetSetType()
    {
        return SetItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when Item1 is not null => Item1.GetType(),
            SetItems.Item2 when Item2 is not null => Item2.GetType(),
            SetItems.Item3 when Item3 is not null => Item3.GetType(),
            SetItems.Item4 when Item4 is not null => Item4.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T1 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T2 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T3 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T4 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2, T3, T4> variant)
    {
        return variant.Get<T>();
    }
    
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item1, SetItems.Item1, value) 
               || SetItemInternal(ref _item2, SetItems.Item2, value)
               || SetItemInternal(ref _item3, SetItems.Item3, value)
               || SetItemInternal(ref _item4, SetItems.Item4, value);
    }

    /// <summary>
    ///     Gets a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static bool TryGet<T>(Variant<T1, T2, T3, T4> variant, out T? value)
    {
        return variant.TryGet(out value);
    }
}