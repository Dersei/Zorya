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
    /// Returns true if the given type is set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool IsSet<T>();

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
    ///     Sets new value without making copy of the class.
    /// </summary>
    /// <param name="value">New value to set.</param>
    /// <typeparam name="T">Type of new value.</typeparam>
    /// <returns>True if set was successful.</returns>
    public bool Set<T>(T value);

    /// <summary>
    ///     Matches set element with a given action. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="BadVariantAccessException"></exception>
    void Match<T>(Action<T> action);

    /// <summary>
    ///     Matches set element with a given action. Executes fallback function if there's no matching type.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="fallback">Fallback action, executed if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    void MatchOrDefault<T>(Action<T> action, Action fallback);

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    bool TryMatch<T>(Action<T> action);

    /// <summary>
    ///     Matches set element with a given function. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <exception cref="BadVariantAccessException"></exception>
    TResult Match<T, TResult>(Func<T, TResult> func);

    /// <summary>
    ///     Matches set element with a given function. Returns default value if there's no matching type.
    /// </summary>
    /// <param name="func"></param>
    /// <param name="default">Default value to return if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    TResult MatchOrDefault<T, TResult>(Func<T, TResult> func, TResult @default);

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <param name="result">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    bool TryMatch<T, TResult>(Func<T, TResult> func, out TResult? result);
}