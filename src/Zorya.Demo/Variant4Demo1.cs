using System.Runtime.CompilerServices;

namespace Zorya.Demo;

public class Variant4Demo<T1, T2, T3, T4>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;

    public Variant4Demo(T1 item1)
    {
        _item1 = item1;
        SetItem = SetItems.Item1;
    }

    public Variant4Demo(T2 item2)
    {
        _item2 = item2;
        SetItem = SetItems.Item2;
    }

    public Variant4Demo(T3 item3)
    {
        _item3 = item3;
        SetItem = SetItems.Item3;
    }

    public Variant4Demo(T4 item4)
    {
        _item4 = item4;
        SetItem = SetItems.Item4;
    }
    

    private SetItems SetItem;

    private enum SetItems : byte
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

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetStandard<T>()
    {
        if (SetItem == SetItems.None)
            return default;
        if (SetItem == SetItems.Item1 && _item1 is T t1)
            return t1;
        if (SetItem == SetItems.Item2 && _item2 is T t2)
            return t2;
        if (SetItem == SetItems.Item3 && _item3 is T t3)
            return t3;
        if (SetItem == SetItems.Item4 && _item4 is T t4)
            return t4;
        return default;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetStandardInline<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            SetItems.Item3 when _item3 is T t3 => t3,
            SetItems.Item4 when _item4 is T t4 => t4,
            _ => default
        };
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetUnsafe<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) => Unsafe.As<T1, T>(ref _item1),
            SetItems.Item2 when typeof(T) == typeof(T2) => Unsafe.As<T2, T>(ref _item2),
            SetItems.Item3 when typeof(T) == typeof(T3) => Unsafe.As<T3, T>(ref _item3),
            SetItems.Item4 when typeof(T) == typeof(T4) => Unsafe.As<T4, T>(ref _item4),
            _ => default
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetUnsafeInline<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) => Unsafe.As<T1, T>(ref _item1),
            SetItems.Item2 when typeof(T) == typeof(T2) => Unsafe.As<T2, T>(ref _item2),
            SetItems.Item3 when typeof(T) == typeof(T3) => Unsafe.As<T3, T>(ref _item3),
            SetItems.Item4 when typeof(T) == typeof(T4) => Unsafe.As<T4, T>(ref _item4),
            _ => default
        };
    }
    
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetUnsafeNullCheck<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is not null => Unsafe.As<T1, T>(ref _item1),
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is not null => Unsafe.As<T2, T>(ref _item2),
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is not null => Unsafe.As<T3, T>(ref _item3),
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is not null => Unsafe.As<T4, T>(ref _item4),
            _ => default
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetUnsafeNullCheckInline<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is not null => Unsafe.As<T1, T>(ref _item1),
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is not null => Unsafe.As<T2, T>(ref _item2),
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is not null => Unsafe.As<T3, T>(ref _item3),
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is not null => Unsafe.As<T4, T>(ref _item4),
            _ => default
        };
    }

    
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // private bool TestItem<TItem, TValue>(TItem item, SetItems setItem, out TValue? value)
    // {
    //     if (SetItem == setItem && item is TValue v)
    //     {
    //         value = v;
    //         return true;
    //     }
    //
    //     value = default;
    //     return false;
    // }
    //
    // //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    // public T? GetTestItem<T>()
    // {
    //     if (SetItem == SetItems.None) return default;
    //     if (TestItem(_item1, SetItems.Item1, out T? result)) return result;
    //     if (TestItem(_item2, SetItems.Item2, out result)) return result;
    //     if (TestItem(_item3, SetItems.Item3, out result)) return result;
    //     if (TestItem(_item4, SetItems.Item4, out result)) return result;
    //     return default;
    // }
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // public T? GetTestItemInline<T>()
    // {
    //     if (SetItem == SetItems.None) return default;
    //     if (TestItem(_item1, SetItems.Item1, out T? result)) return result;
    //     if (TestItem(_item2, SetItems.Item2, out result)) return result;
    //     if (TestItem(_item3, SetItems.Item3, out result)) return result;
    //     if (TestItem(_item4, SetItems.Item4, out result)) return result;
    //     return default;
    // }
}