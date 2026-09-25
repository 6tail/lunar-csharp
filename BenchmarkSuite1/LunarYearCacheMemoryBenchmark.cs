using BenchmarkDotNet.Attributes;
using Lunar;
using Microsoft.VSDiagnostics;

[CPUUsageDiagnoser]
public class LunarYearCacheMemoryBenchmark
{
    private int _year = 1;
    [Benchmark]
    public LunarYear CacheOneDistinctYear()
    {
        return LunarYear.FromYear(_year++);
    }
}