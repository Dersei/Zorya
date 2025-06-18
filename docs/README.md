# Zorya

<img src="https://github.com/Dersei/Zorya/blob/a5781ba2c458a76fbcfb3d68a7f00c7425829c14/build/assets/zorya_icon.png" width="200">

C# implementation of the variant type.
Implementation of the variant type both as a class (`Variant`) and a structure (`ValueVariant`). Both types support up to eight elements and implement implicit cast operators.

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
Additionally, there are also `Match`, `TryMatch` and `MatchOrDefault` methods receiving `Action` or `Func`.
They apply the given function on the element of requested type. `Match` throws `BadVariantAccessException` or `BadValueVariantAccessException`, `TryMatch` returns `true` if the element exists or `false` if it doesn't.
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
`Visit` method accepts one function for all types the variant may contain, and then executes the one corresponding to the set type.
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
Because `ValueVariant` can be initialized without setting any value, it's possible to test if anything is set using `IsValid` method.
```csharp
var v = new ValueVariant<int, string>();
Debug.Assert(v.IsValid()); //false
```
`IsValid` will also return `false` in the following cases:
```csharp
ValueVariant<int, string>() v1 = default;
Debug.Assert(v1.IsValid()); //false
ValueVariant<int, string>() v2 = new ValueVariant<int, string>(null);
Debug.Assert(v2.IsValid()); //false
Variant<int, string>() v3 = null;
Debug.Assert(v3.IsValid()); //false (extension method)
Variant<int, string>() v4 = new Variant<int, string>(null);
Debug.Assert(v4.IsValid()); //false (extension method)
```
Method `IsSet` allows testing if a specified type is set in the variant. 
```csharp
ValueVariant<int, string>() v = 10;
Debug.Assert(v.IsSet<int>()); //true
Debug.Assert(v.IsSet<string>()); //false
```
`Variant` also allows setting a new element without creating a new object using `Set` method which returns `true` if successful:
```csharp
Variant<int, string> v = new (10);
var wasSetSuccess = v.Set("20");
Debug.Assert(v.Get<string>() == "20"); //true
Debug.Assert(wasSetSuccess); //true
```
`Get`, `TryGet`, `Match`, `TryMarch`, `MatchOrDefault` methods are also defined as static on individual types and `Variant`, and `ValueVariant` classes:
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
### Types
Both types allow support only explicitly set types. Although it's possible to set a variant to hold an object of a child class of one of its types, there's no possibility to extract that object in the other way than by using a parent type.
For example:
```csharp
Variant<Parent> v = new Child();
v.Get<Child>(); //throws BadVariantAccessException
v.Get<Parent>(); //returns the Child object
```
The same is true for other methods like `TryGet` or `Visit`.

### IsValid()

Both `Variant` and `ValueVariant` can be in invalid state. There are three possible reasons for that:
1. creating either of the types with the constructor passing in `null` when it's possible.
2. setting `Variant` object to `null`.
3. initialising `ValueVariant` with an empty constructor or `default`.

Method `IsValid` allows checking if the variant is valid. For `Variant` this method is implemented as an extension method allowing `null` check.

Although it's still possible in some cases to pass `null` to constructor, the variant behaviour in such cases will be undefined.

Until the version 1.0.1, due to the way value types and implicit operators work, it was possible to create a `ValueVariant` (with one reference type or `object` and another reference type) using `null`.  
For example: `ValueVariant<string, int> v = null;` or `ValueVariant<string, object, int> v = null;`  
Since the version 1.0.2 such operation will result in a default `ValueVariant` without any value set and with `IsValid` method returning `false`.  

### Equality

Until the version 1.0.1 variants used default equality. Since the version 1.0.2 all variants support `IEquatable` interface, `==`, `!=` operators and `Equals` method.

In case of the `Variant` type two objects `v1` and `v2` are equal if:
1. they have the same type, including the order of types,
2. `v1 is not null && v2 is not null`,
3. `ReferenceEquals(v1, v2)` returns true,
4. otherwise, if they both have the same items set and values of those items are the same.

In case of the `ValueVariant` type two objects `v1` and `v2` are equal if:
1. they have the same type, including the order of types,
2. they both have the same items set and values of those items are the same.

## Name

> Zorya (lit. "Dawn"; also many variants: Zarya, Zara, Zaranitsa, Zoryushka, etc.) is a figure in Slavic folklore, a feminine personification of dawn, possibly goddess. Depending on tradition, she may appear as a singular entity, often called "The Red Maiden", or two or three sisters at once.[^link]

[^link]: [Zorya - Wikipedia](https://en.wikipedia.org/wiki/Zorya).
