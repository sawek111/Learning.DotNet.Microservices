using BenchmarkDotNet.Attributes;

namespace Duplication.Recognition.Benchmark;

[MemoryDiagnoser]
public class RecognitionBenchmark
{
    private static int[] _collection;

    [Params(10, 100)] public int Size { get; set; }
    public double DuplicationIndex { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _collection = Enumerable.Range(1, Size).ToArray();
        var index = (int)DuplicationIndex * Size;
        _collection[index] = _collection[index + 1];
    }

    [Benchmark]
    public bool BruteForceIEnumerableBased()
    {
        return DuplicationRecognizer.BruteForceIEnumerableBased(_collection);
    }

    [Benchmark]
    public bool DistinctBased()
    {
        return DuplicationRecognizer.DistinctBased(_collection);
    }

    [Benchmark]
    public bool GroupByBased()
    {
        return DuplicationRecognizer.GroupByBased(_collection);
    }

    [Benchmark]
    public bool HashSetBased()
    {
        return DuplicationRecognizer.HashSetBased(_collection);
    }

    [Benchmark]
    public bool HashSetLinqBased()
    {
        return DuplicationRecognizer.HashSetLinqBased(_collection);
    }

    [Benchmark]
    public bool HashSetAllLinqBased()
    {
        return DuplicationRecognizer.HashSetAllLinqBased(_collection);
    }

    [Benchmark]
    public bool LinqToHashSetBased()
    {
        return DuplicationRecognizer.LinqToHashSetBased(_collection);
    }

    [Benchmark]
    public bool HashSetOnEnumerableCreatedBased()
    {
        return DuplicationRecognizer.HashSetOnEnumerableCreatedBased(_collection);
    }
}