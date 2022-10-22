using System.Runtime.CompilerServices;

namespace Zorya.Demo;

public class Variant8Demo<T1, T2, T3, T4, T5, T6, T7, T8>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;
    private T5? _item5;
    private T6? _item6;
    private T7? _item7;
    private T8? _item8;

    public Variant8Demo(T1 item1)
    {
        _item1 = item1;
        SetItem = SetItems.Item1;
    }

    public Variant8Demo(T2 item2)
    {
        _item2 = item2;
        SetItem = SetItems.Item2;
    }

    public Variant8Demo(T3 item3)
    {
        _item3 = item3;
        SetItem = SetItems.Item3;
    }

    public Variant8Demo(T4 item4)
    {
        _item4 = item4;
        SetItem = SetItems.Item4;
    }

    public Variant8Demo(T5 item5)
    {
        _item5 = item5;
        SetItem = SetItems.Item5;
    }

    public Variant8Demo(T6 item6)
    {
        _item6 = item6;
        SetItem = SetItems.Item6;
    }

    public Variant8Demo(T7 item7)
    {
        _item7 = item7;
        SetItem = SetItems.Item7;
    }

    public Variant8Demo(T8 item8)
    {
        _item8 = item8;
        SetItem = SetItems.Item8;
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
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            SetItems.Item3 when _item3 is T t3 => t3,
            SetItems.Item4 when _item4 is T t4 => t4,
            SetItems.Item5 when _item5 is T t5 => t5,
            SetItems.Item6 when _item6 is T t6 => t6,
            SetItems.Item7 when _item7 is T t7 => t7,
            SetItems.Item8 when _item8 is T t8 => t8,
            _ => default
        };
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
            SetItems.Item5 when _item5 is T t5 => t5,
            SetItems.Item6 when _item6 is T t6 => t6,
            SetItems.Item7 when _item7 is T t7 => t7,
            SetItems.Item8 when _item8 is T t8 => t8,
            _ => default
        };
    }
    
    public T? GetDoubleCheck<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is T t1 => t1,
            SetItems.Item2 when typeof(T) == typeof(T2) &&_item2 is T t2 => t2,
            SetItems.Item3 when typeof(T) == typeof(T3) &&_item3 is T t3 => t3,
            SetItems.Item4 when typeof(T) == typeof(T4) &&_item4 is T t4 => t4,
            SetItems.Item5 when typeof(T) == typeof(T5) &&_item5 is T t5 => t5,
            SetItems.Item6 when typeof(T) == typeof(T6) &&_item6 is T t6 => t6,
            SetItems.Item7 when typeof(T) == typeof(T7) &&_item7 is T t7 => t7,
            SetItems.Item8 when typeof(T) == typeof(T8) &&_item8 is T t8 => t8,
            _ => default
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetDoubleCheckInline<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) &&_item1 is T t1 => t1,
            SetItems.Item2 when typeof(T) == typeof(T2) &&_item2 is T t2 => t2,
            SetItems.Item3 when typeof(T) == typeof(T3) &&_item3 is T t3 => t3,
            SetItems.Item4 when typeof(T) == typeof(T4) &&_item4 is T t4 => t4,
            SetItems.Item5 when typeof(T) == typeof(T5) &&_item5 is T t5 => t5,
            SetItems.Item6 when typeof(T) == typeof(T6) &&_item6 is T t6 => t6,
            SetItems.Item7 when typeof(T) == typeof(T7) &&_item7 is T t7 => t7,
            SetItems.Item8 when typeof(T) == typeof(T8) &&_item8 is T t8 => t8,
            _ => default
        };
    }
    
    // public T? GetTripleCheck<T>()
    // {
    //     return SetItem switch
    //     {
    //         SetItems.None => default,
    //         SetItems.Item1 when typeof(T) == typeof(T1) &&_item1 != null && _item1 is T t1 => t1,
    //         SetItems.Item2 when typeof(T) == typeof(T2) &&_item2 != null && _item2 is T t2 => t2,
    //         SetItems.Item3 when typeof(T) == typeof(T3) &&_item3 != null && _item3 is T t3 => t3,
    //         SetItems.Item4 when typeof(T) == typeof(T4) &&_item4 != null && _item4 is T t4 => t4,
    //         SetItems.Item5 when typeof(T) == typeof(T5) &&_item5 != null && _item5 is T t5 => t5,
    //         SetItems.Item6 when typeof(T) == typeof(T6) &&_item6 != null && _item6 is T t6 => t6,
    //         SetItems.Item7 when typeof(T) == typeof(T7) &&_item7 != null && _item7 is T t7 => t7,
    //         SetItems.Item8 when typeof(T) == typeof(T8) &&_item8 != null && _item8 is T t8 => t8,
    //         _ => default
    //     };
    // }
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // public T? GetTripleCheckInline<T>()
    // {
    //     return SetItem switch
    //     {
    //         SetItems.None => default,
    //         SetItems.Item1 when typeof(T) == typeof(T1) &&_item1 != null && _item1 is T t1 => t1,
    //         SetItems.Item2 when typeof(T) == typeof(T2) &&_item2 != null && _item2 is T t2 => t2,
    //         SetItems.Item3 when typeof(T) == typeof(T3) &&_item3 != null && _item3 is T t3 => t3,
    //         SetItems.Item4 when typeof(T) == typeof(T4) &&_item4 != null && _item4 is T t4 => t4,
    //         SetItems.Item5 when typeof(T) == typeof(T5) &&_item5 != null && _item5 is T t5 => t5,
    //         SetItems.Item6 when typeof(T) == typeof(T6) &&_item6 != null && _item6 is T t6 => t6,
    //         SetItems.Item7 when typeof(T) == typeof(T7) &&_item7 != null && _item7 is T t7 => t7,
    //         SetItems.Item8 when typeof(T) == typeof(T8) &&_item8 != null && _item8 is T t8 => t8,
    //         _ => default
    //     };
    // }
    
    // public T? GetIf<T>()
    // {
    //     if (SetItem == SetItems.None)
    //         return default;
    //     if (SetItem == SetItems.Item1 && _item1 is T t1)
    //         return t1;
    //     if (SetItem == SetItems.Item2 && _item2 is T t2)
    //         return t2;
    //     if (SetItem == SetItems.Item3 && _item3 is T t3)
    //         return t3;
    //     if (SetItem == SetItems.Item4 && _item4 is T t4)
    //         return t4;
    //     if (SetItem == SetItems.Item5 && _item5 is T t5)
    //         return t5;
    //     if (SetItem == SetItems.Item6 && _item6 is T t6)
    //         return t6;
    //     if (SetItem == SetItems.Item7 && _item7 is T t7)
    //         return t7;
    //     if (SetItem == SetItems.Item8 && _item8 is T t8)
    //         return t8;
    //     return default;
    // }
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // public T? GetIfInline<T>()
    // {
    //     if (SetItem == SetItems.None)
    //         return default;
    //     if (SetItem == SetItems.Item1 && _item1 is T t1)
    //         return t1;
    //     if (SetItem == SetItems.Item2 && _item2 is T t2)
    //         return t2;
    //     if (SetItem == SetItems.Item3 && _item3 is T t3)
    //         return t3;
    //     if (SetItem == SetItems.Item4 && _item4 is T t4)
    //         return t4;
    //     if (SetItem == SetItems.Item5 && _item5 is T t5)
    //         return t5;
    //     if (SetItem == SetItems.Item6 && _item6 is T t6)
    //         return t6;
    //     if (SetItem == SetItems.Item7 && _item7 is T t7)
    //         return t7;
    //     if (SetItem == SetItems.Item8 && _item8 is T t8)
    //         return t8;
    //     return default;
    // }

    public T? GetUnsafe<T>()
    {
        return SetItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) => Unsafe.As<T1, T>(ref _item1),
            SetItems.Item2 when typeof(T) == typeof(T2) => Unsafe.As<T2, T>(ref _item2),
            SetItems.Item3 when typeof(T) == typeof(T3) => Unsafe.As<T3, T>(ref _item3),
            SetItems.Item4 when typeof(T) == typeof(T4) => Unsafe.As<T4, T>(ref _item4),
            SetItems.Item5 when typeof(T) == typeof(T5) => Unsafe.As<T5, T>(ref _item5),
            SetItems.Item6 when typeof(T) == typeof(T6) => Unsafe.As<T6, T>(ref _item6),
            SetItems.Item7 when typeof(T) == typeof(T7) => Unsafe.As<T7, T>(ref _item7),
            SetItems.Item8 when typeof(T) == typeof(T8) => Unsafe.As<T8, T>(ref _item8),
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
            SetItems.Item5 when typeof(T) == typeof(T5) => Unsafe.As<T5, T>(ref _item5),
            SetItems.Item6 when typeof(T) == typeof(T6) => Unsafe.As<T6, T>(ref _item6),
            SetItems.Item7 when typeof(T) == typeof(T7) => Unsafe.As<T7, T>(ref _item7),
            SetItems.Item8 when typeof(T) == typeof(T8) => Unsafe.As<T8, T>(ref _item8),
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
            SetItems.Item5 when typeof(T) == typeof(T5) && _item5 is not null => Unsafe.As<T5, T>(ref _item5),
            SetItems.Item6 when typeof(T) == typeof(T6) && _item6 is not null => Unsafe.As<T6, T>(ref _item6),
            SetItems.Item7 when typeof(T) == typeof(T7) && _item7 is not null => Unsafe.As<T7, T>(ref _item7),
            SetItems.Item8 when typeof(T) == typeof(T8) && _item8 is not null => Unsafe.As<T8, T>(ref _item8),
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
            SetItems.Item5 when typeof(T) == typeof(T5) && _item5 is not null => Unsafe.As<T5, T>(ref _item5),
            SetItems.Item6 when typeof(T) == typeof(T6) && _item6 is not null => Unsafe.As<T6, T>(ref _item6),
            SetItems.Item7 when typeof(T) == typeof(T7) && _item7 is not null => Unsafe.As<T7, T>(ref _item7),
            SetItems.Item8 when typeof(T) == typeof(T8) && _item8 is not null => Unsafe.As<T8, T>(ref _item8),
            _ => default
        };
    }
    
    // //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    // public T? GetUnsafeCastResult<T>()
    // {
    //     object? result = SetItem switch
    //     {
    //         SetItems.None => default,
    //         SetItems.Item1 => _item1,
    //         SetItems.Item2 => _item2,
    //         SetItems.Item3 => _item3,
    //         SetItems.Item4 => _item4,
    //         SetItems.Item5 => _item5,
    //         SetItems.Item6 => _item6,
    //         SetItems.Item7 => _item7,
    //         SetItems.Item8 => _item8,
    //         _ => default
    //     };
    //     return result is T r ? r : default;
    // }
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // public T? GetUnsafeCastResultInline<T>()
    // {
    //     object? result = SetItem switch
    //     {
    //         SetItems.None => default,
    //         SetItems.Item1 => _item1,
    //         SetItems.Item2 => _item2,
    //         SetItems.Item3 => _item3,
    //         SetItems.Item4 => _item4,
    //         SetItems.Item5 => _item5,
    //         SetItems.Item6 => _item6,
    //         SetItems.Item7 => _item7,
    //         SetItems.Item8 => _item8,
    //         _ => default
    //     };
    //     return result is T r ? r : default;
    // } 

    
    // //[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    //     if (TestItem(_item5, SetItems.Item5, out result)) return result;
    //     if (TestItem(_item6, SetItems.Item6, out result)) return result;
    //     if (TestItem(_item7, SetItems.Item7, out result)) return result;
    //     if (TestItem(_item8, SetItems.Item8, out result)) return result;
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
    //     if (TestItem(_item5, SetItems.Item5, out result)) return result;
    //     if (TestItem(_item6, SetItems.Item6, out result)) return result;
    //     if (TestItem(_item7, SetItems.Item7, out result)) return result;
    //     if (TestItem(_item8, SetItems.Item8, out result)) return result;
    //     return default;
    // }
}