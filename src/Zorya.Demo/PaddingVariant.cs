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
    protected SetItems _setItem;
    
    
    public string S;
    public int I;
    public char C;

    protected override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }
}