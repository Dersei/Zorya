# Zorya

<img src="https://user-images.githubusercontent.com/26044987/196815159-5821225b-b35a-4dc0-b593-632874bdd4f2.png" width="200">

 C# implementation of variant type.
Implementation of variant type both as a class (`Variant`) and a structure (`ValueVariant`). Both types supports up to eight elements and implement implicit cast operators.

## Using a variant

```csharp
ValueVariant<int> v = 42;
ValueVariant<int, string> v = "42";
ValueVariant<int, string, double> v = 42.0;
```
or
```csharp
Variant<int> v = 42;
Variant<int, string> v = "42";
Variant<int, string, double> v = 10.0;
```
It's also possible to use a constructor:
```csharp
ValueVariant<int, double, string> v = new (42);
```
### Getting a value
Getting a value is possible with `Get` method which throws `BadVariantAccessException` or `BadValueVariantAccessException` if there's no element of the requested type:
```csharp
Variant<int, string, double> v = 42.0;
v.Get<double>();
```
or with `TryGet` which returns `true` if the element exists or `false` if it doesn't:
```csharp
ValueVariant<int, string, double, long> v = 42L;
if (v.TryGet(out long value))
{
    return value * 2;
}
```
### Using a value
Additionally there are also `Match`, `TryMatch` and `MatchOrDefault` methods receiving `Action` or `Func`.
They apply given function on the element of requested type. `Match` throws `BadVariantAccessException` or `BadValueVariantAccessException`, `TryMatch` returns `true` if the element exists or `false` if it doesn't.
`MatchOrDefault` executes given fallback action in case of `MatchOrDefault(Action)` or returns given default value in case of `MatchOrDefault(Func)`.
```csharp
Variant<int, string, double> v = 42.0;
v.Match((int i) => Console.WriteLine($"int {i}"));
Variant<int, string> v2 = "42";
v2.MatchOrDefault((int i) => Console.WriteLine($"int {i}"), () => Console.WriteLine("Incorrect type"));
Variant<int, double> v3 = 42.0;
if(v3.TryMatch((int i) => i * 10, out var result))
{
    Console.WriteLine(result);
}
```
### Visit
`Visit` method accepts one function for all types the variant may contain and then executes the one corresponding to the set type.
```csharp
Variant<int, double, string> v = 42.0;
v.Visit((int i) => Console.WriteLine($"int {i}"), (double d) => Console.WriteLine($"double {d}", (string s) => Console.WriteLine($"string {s}");
```
### Additional capabilities
It's also possible to request the set type using `GetSetType`:
```csharp
Variant<int, string, double, Point> v = new Point(0, 1);
if(v.GetSetType() == typeof(Point))
{
}
```
Because `ValueVariant` can be initialized without setting any value, it's possible to test if any item is set using `IsSet` method.
```csharp
var v = new ValueVariant<int, string>();
Debug.Assert(v.IsSet()); //false
```
`Variant` also allows to set a new element without creating a new object using `Set` method which returns `true` if successful:
```csharp
Variant<int, string> v = new (10);
var wasSetSuccess = v.Set("20");
Debug.Assert(v.Get<string>() == "20"); //true
Debug.Assert(wasSetSuccess); //true
```
`Get`, `TryGet`, `Match`, `TryMarch`, `MatchOrDefault` methods are also define as static on individual types and `Variant`, and `ValueVariant` classes:
```csharp
Variant<int, string, double, long> v = 42L;
var l = Variant.Get<long>(v);
```
or
```csharp
Variant<int, string, double, long> v = 42L;
var l = Variant<int, string, double, long>.Get<long>(v);
```
## Example of use case

```csharp
Variant<int, double, string> ParseInput(string input)
{
    if (int.TryParse(input, out var i))
    {
        return i;
    }
    if (double.TryParse(input, out var d))
    {
        return d;
    }
    return input;
}
```

## Remarks

Until the version 1.0.1, due to the way value types and implicit operators work, it was possible to create a `ValueVariant` (with one reference type or `object` and another reference type) using `null`.  
For example: `ValueVariant<string, int> v = null;` or `ValueVariant<string, object, int> v = null;`  
Since the version 1.0.2 such operation will result in a default `ValueVariant` without any value set and with `IsSet` method returning `false`.  
It's still possible to explicitly set a variant to `null` using its constructor.

Until the version 1.0.1 variants used default equality. Since the version 1.0.2 all variants support `IEquatable` interface, `==`, `!=` operators and `Equals` method.

In case of the `Variant` type two objects `v1` and `v2` are equal if:
1. they have the same type, including the order of types,
2. `v1 is not null && v2 is not null`,
3. `ReferenceEquals(v1, v2)` returns true,
4. otherwise if they both have the same items set and values of those items are the same.

In case of the `ValueVariant` type two objects `v1` and `v2` are equal if:
1. they have the same type, including the order of types,
2. they both have the same items set and values of those items are the same.
## Name

> Zorya (lit. "Dawn"; also many variants: Zarya, Zara, Zaranitsa, Zoryushka, etc.) is a figure in Slavic folklore, a feminine personification of dawn, possibly goddess. Depending on tradition, she may appear as a singular entity, often called "The Red Maiden", or two or three sisters at once.[^link]

[^link]: [Zorya - Wikipedia](https://en.wikipedia.org/wiki/Zorya).
