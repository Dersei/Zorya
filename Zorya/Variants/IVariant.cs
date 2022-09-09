namespace Zorya.Variants;

public interface IVariant
{
    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public T Get<T>();

    /// <summary>
    ///     Gets a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public bool TryGet<T>(out T? value);

    /// <summary>
    ///     Returns type set in variant.
    /// </summary>
    /// <returns></returns>
    public Type? GetSetType();
    
    /// <summary>
    /// Sets new value without making copy of the class.
    /// </summary>
    /// <param name="value">New value to set.</param>
    /// <typeparam name="T">Type of new value.</typeparam>
    /// <returns>True if set was successful.</returns>
    public bool Set<T>(T value);
}