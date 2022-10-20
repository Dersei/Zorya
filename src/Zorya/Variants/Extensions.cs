namespace Zorya.Variants;

public static class Extensions
{
    /// <summary>
    /// Checks if variant is null.
    /// </summary>
    /// <param name="variant"></param>
    /// <returns></returns>
    public static bool IsSet(this IVariant? variant) => variant?.GetSetType() != null;
}