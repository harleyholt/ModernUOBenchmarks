using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using Server;

namespace ModernUOBenchmarks;

[MemoryDiagnoser]
public class ToStringBenchmarks
{
    private Point2D[] points;

    public ToStringBenchmarks() {
        points = new Point2D[] {
            new Server.Point2D(1, 1),
            new Server.Point2D(2, 2),
            new Server.Point2D(3, 3)
        };
    }

    [Benchmark]
    public string CallToString() {
        return points[0].ToString();
    }

    [Benchmark]
    public string InterpolatedString() {
        return $"{points[0]}";
    }

    [Benchmark]
    public string InterpolatedStringMultiplePoints() {
        return $"{points[0]} {points[1]} {points[2]}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ToStringBenchmarks>();
    }
}