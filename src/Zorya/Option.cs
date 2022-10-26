namespace Zorya;

public readonly struct Option<T> where T : class?
{
    private readonly T? _value;

    public Option(T value) => _value = value;

    public bool IsSet => _value != null;
}