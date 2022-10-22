using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
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

// TypeLayout.PrintLayout<ValueVariant<int, string, char, byte, long, double, object, decimal>>();
// TypeLayout.PrintLayout<ValueVariant<int, string, char, byte>>();
// TypeLayout.PrintLayout<ValueVariant<int, string, char>>();

// Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>(true);
// Console.WriteLine(v.GetUnsafe<bool>());
//
// return;

// Variant8Demo<int, decimal, char, byte, object, long, string, bool> v = null;
//
//     v = new Variant8Demo<int, decimal, char, byte, object, long, string, bool>("true");
//     v.GetUnsafeCastResultInline<string>();
// return;
BenchmarkRunner.Run<GetBenchmark>(DefaultConfig.Instance
    .AddColumn(TargetMethodColumn.Method)
    .AddColumn(StatisticColumn.Mean)
    .AddColumn(StatisticColumn.Median)
    .AddColumn(StatisticColumn.Min)
    .AddColumn(StatisticColumn.Max)
    .AddColumn(StatisticColumn.OperationsPerSecond)
    .AddColumn(RankColumn.Arabic)
    .AddExporter(CsvExporter.Default)
    .AddExporter(CsvMeasurementsExporter.Default)
    .AddLogger(ConsoleLogger.Default)
    .AddDiagnoser(MemoryDiagnoser.Default));