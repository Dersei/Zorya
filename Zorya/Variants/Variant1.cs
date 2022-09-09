using System.Diagnostics.CodeAnalysis;

namespace Zorya.Variants;

public class Variant<T1> : Variant, IVariant
{
    private T1? _item;

    public Variant(T1 item)
    {
        Item = item;
        SetItem = SetItems.Item1;
    }

    private T1? Item
    {
        get => _item;
        init => _item = value;
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
            SetItems.Item1 when Item is T t => t,
            _ => throw new BadVariantAccessException(typeof(T1), this)
        };
    }


    public override bool TryGet<T>([MaybeNull] out T value)
    {
        return TestItem(Item, SetItems.Item1, out value);
    }

    public override Type? GetSetType()
    {
        return SetItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when Item is not null => Item.GetType(),
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
}