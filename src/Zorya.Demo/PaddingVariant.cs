using System.Runtime.CompilerServices;

namespace Zorya.Demo;

public abstract class PaddingVariantParentField
{
    protected SetItems SetItem;
    
    protected enum SetItems : byte
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

    public string GetSetItem()
    {
        return SetItem.ToString();
    }
}

public class PaddingVariantChildField : PaddingVariantParentField
{
    public string S;
    public int I;
    public char C;
}

public abstract class PaddingVariantParentProperty
{
    protected abstract SetItems SetItem { get; set; }

    public abstract string Test();

    public abstract string TestInline();
    
    protected enum SetItems : byte
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

    public string GetSetItem()
    {
        return SetItem.ToString();
    }
}

public class PaddingVariantChildProperty : PaddingVariantParentProperty
{
    private SetItems _setItem;
    
    
    private string S;
    private int I;
    private char C;

    protected override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string TestInline()
    {
        return _setItem + S + I + C;
    }

    public override string Test()
    {
        return _setItem + S + I + C;
    }
}

public class PaddingVariantChildPropertyInline : PaddingVariantParentProperty
{
    private SetItems _setItem;
    
    
    private string S;
    private int I;
    private char C;

    protected override SetItems SetItem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _setItem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _setItem = value;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string TestInline()
    {
        return _setItem + S + I + C;
    }

    public override string Test()
    {
        return _setItem + S + I + C;
    }
}

public sealed class PaddingVariantChildPropertySealed : PaddingVariantParentProperty
{
    private SetItems _setItem;
    
    
    private string S;
    private int I;
    private char C;

    protected override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }
    
    public override string Test()
    {
        return _setItem + S + I + C;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string TestInline()
    {
        return _setItem + S + I + C;
    }
}

public class PaddingVariantChildPropertySealedOnly : PaddingVariantParentProperty
{
    private SetItems _setItem;
    
    
    private string S;
    private int I;
    private char C;

    protected sealed override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }
    
    public override string Test()
    {
        return _setItem + S + I + C;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string TestInline()
    {
        return _setItem + S + I + C;
    }
}

public abstract class PaddingVariantParentMethod
{
    protected abstract SetItems SetItem();
    
    protected enum SetItems : byte
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

    public string GetSetItem()
    {
        return SetItem().ToString();
    }
}

public class PaddingVariantChildMethodSealed : PaddingVariantParentMethod
{
    private SetItems _setItems;
    private string S;
    private int I;
    private char C;
    
    protected sealed override SetItems SetItem()
    {
        return _setItems;
    }
}

public class PaddingVariantChildMethod : PaddingVariantParentMethod
{
    private SetItems _setItems;
    private string S;
    private int I;
    private char C;
    
    protected override SetItems SetItem()
    {
        return _setItems;
    }
}

public class PaddingVariantChildMethodInline : PaddingVariantParentMethod
{
    private SetItems _setItems;
    private string S;
    private int I;
    private char C;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override SetItems SetItem()
    {
        return _setItems;
    }
}

public class PaddingVariantChildMethodSealedInline : PaddingVariantParentMethod
{
    private SetItems _setItems;
     private string S;
        private int I;
        private char C;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override SetItems SetItem()
    {
        return _setItems;
    }
}



