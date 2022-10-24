using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Zorya.Variants;

namespace Zorya.Demo;

public enum SetItems : byte
{
    None,
    Item1,
    Item2,
    Item3,
    Item4,
    Item5,
    Item6,
    Item7,
    Item8
}

public struct ImplVariantClassicStruct<T1, T2, T3, T4, T5, T6, T7, T8>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;
    private T5? _item5;
    private T6? _item6;
    private T7? _item7;
    private T8? _item8;

    private ImplVariantClassicStruct(bool _)
    {
        Unsafe.SkipInit(out _item1);
        Unsafe.SkipInit(out _item2);
        Unsafe.SkipInit(out _item3);
        Unsafe.SkipInit(out _item4);
        Unsafe.SkipInit(out _item5);
        Unsafe.SkipInit(out _item6);
        Unsafe.SkipInit(out _item7);
        Unsafe.SkipInit(out _item8);
    }

    
    private SetItems _setItem = SetItems.None;

    private SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }

    public ImplVariantClassicStruct(T1 item1) : this(true)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public ImplVariantClassicStruct(T2 item2) : this(true)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    public ImplVariantClassicStruct(T3 item3) : this(true)
    {
        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public ImplVariantClassicStruct(T4 item4) : this(true)
    {
        _item4 = item4;
        _setItem = SetItems.Item4;
    }

    public ImplVariantClassicStruct(T5 item5) : this(true)
    {
        _item5 = item5;
        _setItem = SetItems.Item5;
    }

    public ImplVariantClassicStruct(T6 item6) : this(true)
    {
        _item6 = item6;
        _setItem = SetItems.Item6;
    }

    public ImplVariantClassicStruct(T7 item7) : this(true)
    {
        _item7 = item7;
        _setItem = SetItems.Item7;
    }

    public ImplVariantClassicStruct(T8 item8) : this(true)
    {
        _item8 = item8;
        _setItem = SetItems.Item8;
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new InvalidCastException(),
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is T t1 => t1,
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is T t2 => t2,
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is T t3 => t3,
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is T t4 => t4,
            SetItems.Item5 when typeof(T) == typeof(T5) && _item5 is T t5 => t5,
            SetItems.Item6 when typeof(T) == typeof(T6) && _item6 is T t6 => t6,
            SetItems.Item7 when typeof(T) == typeof(T7) && _item7 is T t7 => t7,
            SetItems.Item8 when typeof(T) == typeof(T8) && _item8 is T t8 => t8,
            _ => default
        };
    }
    
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4,
        Action<T5> action5, Action<T6> action6, Action<T7> action7, Action<T8> action8)
    {
        if (_setItem == SetItems.Item1 && _item1 is not null) action1(_item1);
        if (_setItem == SetItems.Item2 && _item2 is not null) action2(_item2);
        if (_setItem == SetItems.Item3 && _item3 is not null) action3(_item3);
        if (_setItem == SetItems.Item4 && _item4 is not null) action4(_item4);
        if (_setItem == SetItems.Item5 && _item5 is not null) action5(_item5);
        if (_setItem == SetItems.Item6 && _item6 is not null) action6(_item6);
        if (_setItem == SetItems.Item7 && _item7 is not null) action7(_item7);
        if (_setItem == SetItems.Item8 && _item8 is not null) action8(_item8);
    }
}

public interface IVariantHandlerStruct
{
    bool Is<T>();

    object Get();
    bool IsValid();

}

public readonly struct VariantHandlerStruct<T> : IVariantHandlerStruct
{
    public readonly T Item;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Is<U>() => typeof(U) == typeof(T);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public object Get() => Item;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsValid() => Item != null;

    public VariantHandlerStruct(T item) => Item = item;
}

public struct ImplVariantHandlerStruct<T1, T2, T3, T4, T5, T6, T7, T8> 
{
    private readonly IVariantHandlerStruct _item;

    private SetItems _setItem;

    private SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }

    public ImplVariantHandlerStruct(T1 item)
    {
        _item = new VariantHandlerStruct<T1>(item);
        _setItem = SetItems.Item1;
    }

    public ImplVariantHandlerStruct(T2 item)
    {
        _item = new VariantHandlerStruct<T2>(item);
        _setItem = SetItems.Item2;
    }

    public ImplVariantHandlerStruct(T3 item)
    {
        _item = new VariantHandlerStruct<T3>(item);
        _setItem = SetItems.Item3;
    }

    public ImplVariantHandlerStruct(T4 item)
    {
        _item = new VariantHandlerStruct<T4>(item);
        _setItem = SetItems.Item4;
    }

    public ImplVariantHandlerStruct(T5 item)
    {
        _item = new VariantHandlerStruct<T5>(item);
        _setItem = SetItems.Item5;
    }

    public ImplVariantHandlerStruct(T6 item)
    {
        _item = new VariantHandlerStruct<T6>(item);
        _setItem = SetItems.Item6;
    }

    public ImplVariantHandlerStruct(T7 item)
    {
        _item = new VariantHandlerStruct<T7>(item);
        _setItem = SetItems.Item7;
    }

    public ImplVariantHandlerStruct(T8 item)
    {
        _item = new VariantHandlerStruct<T8>(item);
        _setItem = SetItems.Item8;
    }

    ///<inheritdoc />
    [return:MaybeNull]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Get<T>()
    {
        if (_item is VariantHandlerStruct<T> vh)
            return vh.Item;
        return default;
    }
    
    ///<inheritdoc />
    [return:MaybeNull]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetNull<T>()
    {
        if (_item is VariantHandlerStruct<T> vh)
        {
            var item = vh.Item;
            return item != null ? item : default;
        }
        return default;
    }
    
    [return:MaybeNull]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetPattern<T>()
    {
        if (_item is VariantHandlerStruct<T> {Item: {} item})
            return item;
        return default;
    }
    
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4,
        Action<T5> action5, Action<T6> action6, Action<T7> action7, Action<T8> action8)
    {
        if (_setItem == SetItems.Item1 && _item is VariantHandlerStruct<T1> { Item : {} value1 }) action1(value1);
        if (_setItem == SetItems.Item2 && _item is VariantHandlerStruct<T2> { Item : {} value2 }) action2(value2);
        if (_setItem == SetItems.Item3 && _item is VariantHandlerStruct<T3> { Item : {} value3 }) action3(value3);
        if (_setItem == SetItems.Item4 && _item is VariantHandlerStruct<T4> { Item : {} value4 }) action4(value4);
        if (_setItem == SetItems.Item5 && _item is VariantHandlerStruct<T5> { Item : {} value5 }) action5(value5);
        if (_setItem == SetItems.Item6 && _item is VariantHandlerStruct<T6> { Item : {} value6 }) action6(value6);
        if (_setItem == SetItems.Item7 && _item is VariantHandlerStruct<T7> { Item : {} value7 }) action7(value7);
        if (_setItem == SetItems.Item8 && _item is VariantHandlerStruct<T8> { Item : {} value8 }) action8(value8);

    }
}
