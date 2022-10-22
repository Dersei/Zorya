using System.Runtime.CompilerServices;

namespace Zorya.Demo;

public class Variant4DemoNullCheck<T1, T2, T3, T4>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;

    public Variant4DemoNullCheck(T1 item1)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public Variant4DemoNullCheck(T2 item2)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    public Variant4DemoNullCheck(T3 item3)
    {
        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public Variant4DemoNullCheck(T4 item4)
    {
        _item4 = item4;
        _setItem = SetItems.Item4;
    }


    private SetItems _setItem;

    private enum SetItems : byte
    {
        None,
        Item1,
        Item2,
        Item3,
        Item4,
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? Get<T>()
    {
        return _setItem switch
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
    public T? GetWithTypeOf<T>()
    {
        return _setItem switch
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
    public T? GetWithTypeOfNullCheck<T>()
    {
        return _setItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is not null => Unsafe.As<T1, T>(ref _item1),
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is not null => Unsafe.As<T2, T>(ref _item2),
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is not null => Unsafe.As<T3, T>(ref _item3),
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is not null => Unsafe.As<T4, T>(ref _item4),
            _ => default
        };
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
            _ => null
        };
    }

    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
    {
        if (_setItem == SetItems.None) return;
        if (_setItem == SetItems.Item1 && _item1 is not null) action1(_item1);
        if (_setItem == SetItems.Item2 && _item2 is not null) action2(_item2);
        if (_setItem == SetItems.Item3 && _item3 is not null) action3(_item3);
        if (_setItem == SetItems.Item4 && _item4 is not null) action4(_item4);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TestItem<TItem, TValue>(TItem item, SetItems setItem, out TValue? value)
    {
        if (_setItem == setItem && item is TValue v)
        {
            value = v;
            return true;
        }

        value = default;
        return false;
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetWithTest<T>()
    {
        if (_setItem == SetItems.None) return default;
        T? result;
        if (TestItem(_item1, SetItems.Item1, out result)) return result;
        if (TestItem(_item2, SetItems.Item2, out result)) return result;
        if (TestItem(_item3, SetItems.Item3, out result)) return result;
        if (TestItem(_item4, SetItems.Item4, out result)) return result;
        return default;
    }

    public bool TryGet<T>(out T? value)
    {
        if (TestItem(_item1, SetItems.Item1, out value)) return true;
        if (TestItem(_item2, SetItems.Item2, out value)) return true;
        if (TestItem(_item3, SetItems.Item3, out value)) return true;
        return TestItem(_item4, SetItems.Item4, out value);
    }
}

public class Variant4DemoNullBlock<T1, T2, T3, T4>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;

    public Variant4DemoNullBlock(T1 item1)
    {
        if (item1 is null)
        {
            _setItem = SetItems.None;
            return;
        }

        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public Variant4DemoNullBlock(T2 item2)
    {
        if (item2 is null)
        {
            return;
        }

        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    public Variant4DemoNullBlock(T3 item3)
    {
        if (item3 is null)
        {
            return;
        }

        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public Variant4DemoNullBlock(T4 item4)
    {
        if (item4 is null)
        {
            return;
        }

        _item4 = item4;
        _setItem = SetItems.Item4;
    }


    private SetItems _setItem;

    private enum SetItems : byte
    {
        None,
        Item1,
        Item2,
        Item3,
        Item4,
    }

    public T? Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => default,
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            SetItems.Item3 when _item3 is T t3 => t3,
            SetItems.Item4 when _item4 is T t4 => t4,
            _ => default
        };
    }

    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 => _item1.GetType(),
            SetItems.Item2 => _item2.GetType(),
            SetItems.Item3 => _item3.GetType(),
            SetItems.Item4 => _item4.GetType(),
            _ => null
        };
    }

    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
    {
        if (_setItem == SetItems.None) return;
        if (_setItem == SetItems.Item1) action1(_item1);
        if (_setItem == SetItems.Item2) action2(_item2);
        if (_setItem == SetItems.Item3) action3(_item3);
        if (_setItem == SetItems.Item4) action4(_item4);
    }
}