using System.Diagnostics.CodeAnalysis;

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

    ///<inheritdoc />
    public override T Get<T>()
    {
        return SetItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T), this),
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            SetItems.Item3 when _item3 is T t3 => t3,
            SetItems.Item4 when _item4 is T t4 => t4,
            _ => throw new BadVariantAccessException(typeof(T), this)
        };
    }

    ///<inheritdoc />
    public override bool TryGet<T>([MaybeNull] out T value)
    {
        if (TestItem(_item1, SetItems.Item1, out value)) return true;
        if (TestItem(_item2, SetItems.Item2, out value)) return true;
        if (TestItem(_item3, SetItems.Item3, out value)) return true;
        return TestItem(_item4, SetItems.Item4, out value);
    }

    ///<inheritdoc />
    public override Type? GetSetType()
    {
        return SetItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => _item1.GetType(),
            SetItems.Item2 when _item2 is not null => _item2.GetType(),
            SetItems.Item3 when _item3 is not null => _item3.GetType(),
            SetItems.Item4 when _item4 is not null => _item4.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item1, SetItems.Item1, value)
               || SetItemInternal(ref _item2, SetItems.Item2, value)
               || SetItemInternal(ref _item3, SetItems.Item3, value)
               || SetItemInternal(ref _item4, SetItems.Item4, value);
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

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
    {
        if (SetItem == SetItems.Item1) action1(_item1!);
        if (SetItem == SetItems.Item2) action2(_item2!);
        if (SetItem == SetItems.Item3) action3(_item3!);
        if (SetItem == SetItems.Item4) action4(_item4!);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3,
        Func<T4, TResult> func4)
    {
        return SetItem switch
        {
            SetItems.Item1 => func1(_item1!),
            SetItems.Item2 => func2(_item2!),
            SetItems.Item3 => func3(_item3!),
            SetItems.Item4 => func4(_item4!),
            _ => default
        };
    }
    
    public override string ToString()
    {
        return SetItem switch
        {
            SetItems.Item1 => _item1?.ToString(),
            SetItems.Item2 => _item2?.ToString(),
            SetItems.Item3 => _item3?.ToString(),
            SetItems.Item4 => _item4?.ToString(),
            _ => string.Empty
        } ?? string.Empty;
    }
}