using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using ObjectLayoutInspector;
using Zorya.Demo;
using Zorya.ValueVariants;
using Zorya.Variants;

// Variant<int, double, string> ParseInput(string input)
// {
//     if (int.TryParse(input, out var i)) return i;
//     if (double.TryParse(input, out var d)) return d;
//     return input;
// }
//
// Console.WriteLine("Input value:");
// var parsed = ParseInput(Console.ReadLine() ?? string.Empty);
// Console.WriteLine($"Your input is of type {parsed.Visit(_ => "int", _ => "double", _ => "string")}");
//
// var v = new Variant<int, string, char>('c');
//
// v.Match((char c) => Console.WriteLine(c));
//
// TypeLayout.PrintLayout<Variant<decimal, decimal, decimal>>();
// TypeLayout.PrintLayout<Variant<object, object, object>>();
// TypeLayout.PrintLayout<Variant<byte, byte, byte>>();
// TypeLayout.PrintLayout<Variant<int, string, bool>>();
// TypeLayout.PrintLayout<ImplVariantHandlerStruct<int, decimal, char, byte, object, long, string, bool>>();
// TypeLayout.PrintLayout<ImplVariantClassicStruct<int, decimal, char, byte, object, long, string, bool>>();
// return;

BenchmarkRunner.Run<GetLibraryBenchmark>(DefaultConfig.Instance
    .AddColumn(TargetMethodColumn.Method)
    .AddColumn(StatisticColumn.Mean)
    .AddColumn(StatisticColumn.Median)
    .HideColumns(StatisticColumn.StdDev)
    .HideColumns(BaselineRatioColumn.RatioMean)
    .HideColumns(BaselineRatioColumn.RatioStdDev)
    .AddColumn(StatisticColumn.OperationsPerSecond)
    .AddColumn(RankColumn.Arabic)
    .AddLogger(ConsoleLogger.Default)
    .AddDiagnoser(MemoryDiagnoser.Default));