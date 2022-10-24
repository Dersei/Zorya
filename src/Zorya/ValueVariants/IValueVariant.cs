﻿namespace Zorya.ValueVariants;

public interface IValueVariant
{
    /// <summary>
    ///     Returns type set in variant.
    /// </summary>
    /// <returns></returns>
    Type? GetSetType();
    
    /// <summary>
    ///     Returns true if variant is valid.
    /// </summary>
    /// <returns></returns>
    bool IsValid();

    /// <summary>
    /// Returns true if the given type is set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool IsSet<T>();

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    T Get<T>();

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    bool TryGet<T>(out T? value);
}