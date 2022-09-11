using Zorya.Variants;

Variant<int, double, string> ParseInput(string input)
{
    if (int.TryParse(input, out var i)) return i;
    if (double.TryParse(input, out var d)) return d;
    return input;
}

Console.WriteLine("Input value:");
var parsed = ParseInput(Console.ReadLine() ?? string.Empty);
Console.WriteLine($"Your input is of type {parsed.Visit(_ => "int", _ => "double", _ => "string")}");

var v = new Variant<int, string, char>('c');

v.Match((char c) => Console.WriteLine(c));