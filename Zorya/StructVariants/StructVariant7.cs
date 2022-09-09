using System.Runtime.CompilerServices;

namespace Zorya.StructVariants;

public readonly struct StructVariant<T1, T2, T3, T4, T5, T6, T7> : IStructVariant
{
    private StructVariant(bool _)
    {
        Unsafe.SkipInit(out _item1);
        Unsafe.SkipInit(out _item2);
        Unsafe.SkipInit(out _item3);
        Unsafe.SkipInit(out _item4);
        Unsafe.SkipInit(out _item5);
        Unsafe.SkipInit(out _item6);
        Unsafe.SkipInit(out _item7);
    }

    public StructVariant(T1 item1) : this(true)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public StructVariant(T2 item2) : this(true)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    public StructVariant(T3 item3) : this(true)
    {
        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public StructVariant(T4 item4) : this(true)
    {
        _item4 = item4;
        _setItem = SetItems.Item4;
    }

    public StructVariant(T5 item5) : this(true)
    {
        _item5 = item5;
        _setItem = SetItems.Item5;
    }

    public StructVariant(T6 item6) : this(true)
    {
        _item6 = item6;
        _setItem = SetItems.Item6;
    }

    public StructVariant(T7 item7) : this(true)
    {
        _item7 = item7;
        _setItem = SetItems.Item7;
    }


    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T1 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T2 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T3 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T4 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T5 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T6 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator StructVariant<T1, T2, T3, T4, T5, T6, T7>(T7 value)
    {
        return new StructVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    private readonly SetItems _setItem = SetItems.None;


    private readonly T1? _item1;

    private readonly T2? _item2;
    private readonly T3? _item3;
    private readonly T4? _item4;
    private readonly T5? _item5;
    private readonly T6? _item6;
    private readonly T7? _item7;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadStructVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(StructVariant<T1, T2, T3, T4, T5, T6, T7> variant)
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
    public static bool TryGet<T>(StructVariant<T1, T2, T3, T4, T5, T6, T7> variant, out T? value)
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
            SetItems.Item3 when _item3 is T t3 => t3,
            SetItems.Item4 when _item4 is T t4 => t4,
            SetItems.Item5 when _item5 is T t5 => t5,
            SetItems.Item6 when _item6 is T t6 => t6,
            SetItems.Item7 when _item7 is T t7 => t7,
            _ => throw new BadStructVariantAccessException(typeof(T), this)
        };
    }

    public bool TryGet<T>(out T? value)
    {
        if (StructVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        if (StructVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value)) return true;
        if (StructVariant.TestItem(_item3, SetItems.Item3 == _setItem, out value)) return true;
        if (StructVariant.TestItem(_item4, SetItems.Item4 == _setItem, out value)) return true;
        if (StructVariant.TestItem(_item5, SetItems.Item5 == _setItem, out value)) return true;
        if (StructVariant.TestItem(_item6, SetItems.Item6 == _setItem, out value)) return true;
        return StructVariant.TestItem(_item7, SetItems.Item7 == _setItem, out value);
    }


    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => _item1.GetType(),
            SetItems.Item2 when _item2 is not null => _item2.GetType(),
            SetItems.Item3 when _item3 is not null => _item3.GetType(),
            SetItems.Item4 when _item4 is not null => _item4.GetType(),
            SetItems.Item5 when _item5 is not null => _item5.GetType(),
            SetItems.Item6 when _item6 is not null => _item6.GetType(),
            SetItems.Item7 when _item7 is not null => _item7.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}