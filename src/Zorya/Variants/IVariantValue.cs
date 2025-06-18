using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public interface IVariantValue
{
    bool Is<T>();
    object? Get();
    Type GetSetType();
    bool IsValid();
}

public sealed class VariantValue<T> : IVariantValue, IEquatable<VariantValue<T>>
{
    public readonly T? Item;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Is<TValue>() => typeof(TValue) == typeof(T);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public object? Get() => Item;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Type GetSetType() => typeof(T);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsValid() => Item != null;
    public VariantValue(T item) => Item = item;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string? ToString() => Item?.ToString();

    public bool Equals(VariantValue<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<T>.Default.Equals(Item, other.Item);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is VariantValue<T> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Item);
    }
}