using System.Diagnostics.CodeAnalysis;

namespace Zorya.Variants;

public class Variant<T1, T2, T3, T4, T5, T6> : Variant, IVariant
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;
    private T5? _item5;
    private T6? _item6;

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

    public Variant(T5 item5)
    {
        _item5 = item5;
        SetItem = SetItems.Item5;
    }

    public Variant(T6 item6)
    {
        _item6 = item6;
        SetItem = SetItems.Item6;
    }

    private T1? Item1 => _item1;

    private T2? Item2 => _item2;

    private T3? Item3 => _item3;

    private T4? Item4 => _item4;

    private T5? Item5 => _item5;

    private T6? Item6 => _item6;

    public override T Get<T>()
    {
        return SetItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T), this),
            SetItems.Item1 when Item1 is T t1 => t1,
            SetItems.Item2 when Item2 is T t2 => t2,
            SetItems.Item3 when Item3 is T t3 => t3,
            SetItems.Item4 when Item4 is T t4 => t4,
            SetItems.Item5 when Item5 is T t5 => t5,
            SetItems.Item6 when Item6 is T t6 => t6,
            _ => throw new BadVariantAccessException(typeof(T), this)
        };
    }

    public override bool TryGet<T>([MaybeNull] out T value)
    {
        if (TestItem(Item1, SetItems.Item1, out value)) return true;
        if (TestItem(Item2, SetItems.Item2, out value)) return true;
        if (TestItem(Item3, SetItems.Item3, out value)) return true;
        if (TestItem(Item4, SetItems.Item4, out value)) return true;
        if (TestItem(Item5, SetItems.Item5, out value)) return true;
        return TestItem(Item6, SetItems.Item6, out value);
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
            SetItems.Item5 when Item5 is not null => Item5.GetType(),
            SetItems.Item6 when Item6 is not null => Item6.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }


    public static implicit operator Variant<T1, T2, T3, T4, T5, T6>(T1 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6>(T2 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6>(T3 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6>(T4 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6>(T5 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6>(T6 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6>(value);
    }
    
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item1, SetItems.Item1, value) 
               || SetItemInternal(ref _item2, SetItems.Item2, value)
               || SetItemInternal(ref _item3, SetItems.Item3, value)
               || SetItemInternal(ref _item4, SetItems.Item4, value)
               || SetItemInternal(ref _item5, SetItems.Item5, value)
               || SetItemInternal(ref _item6, SetItems.Item6, value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2, T3, T4, T5, T6> variant)
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
    public static bool TryGet<T>(Variant<T1, T2, T3, T4, T5, T6> variant, out T? value)
    {
        return variant.TryGet(out value);
    }
}