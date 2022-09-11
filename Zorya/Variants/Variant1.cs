using System.Diagnostics.CodeAnalysis;

namespace Zorya.Variants;

public class Variant<T1> : Variant, IVariant
{
    private T1? _item;

    public Variant(T1 item)
    {
        _item = item;
        SetItem = SetItems.Item1;
    }

    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item, SetItems.Item1, value);
    }

    public override T Get<T>()
    {
        return SetItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T1), this),
            SetItems.Item1 when _item is T t => t,
            _ => throw new BadVariantAccessException(typeof(T1), this)
        };
    }


    public override bool TryGet<T>([MaybeNull] out T value)
    {
        return TestItem(_item, SetItems.Item1, out value);
    }

    public override Type? GetSetType()
    {
        return SetItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item is not null => _item.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static implicit operator Variant<T1>(T1 value)
    {
        return new Variant<T1>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T> variant)
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
    public static bool TryGet<T>(Variant<T> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action)
    {
        if (SetItem == SetItems.Item1) action(_item!);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func)
    {
        if (SetItem == SetItems.Item1) return func(_item!);
        return default;
    }
}