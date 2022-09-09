namespace Zorya.StructVariants;

internal enum SetItems : byte
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

internal static class StructVariant
{
    internal static bool TestItem<TItem, TValue>(TItem item, bool isCorrectItem, out TValue? value)
    {
        if (item is TValue v && isCorrectItem)
        {
            value = v;
            return true;
        }

        value = default;
        return false;
    }
}