namespace Duplication.Recognition.Benchmark;

public static class DuplicationRecognizer
{
    public static bool BruteForceIEnumerableBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        var i = -1;

        foreach (var outerValue in enumerable)
        {
            i++;
            var j = -1;
            foreach (var innerValue in enumerable)
            {
                j++;
                if (j == i)
                {
                    continue;
                }

                if (outerValue.Equals(innerValue))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool HashSetBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        HashSet<T> set = new();
        foreach (var comparable in enumerable)
        {
            if (!set.Add(comparable))
            {
                return true;
            }
        }

        return false;
    }

    public static bool HashSetLinqBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        HashSet<T> set = new();
        return enumerable.Any(comparable => !set.Add(comparable));
    }

    public static bool HashSetAllLinqBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        HashSet<T> set = new();
        return !enumerable.All(comparable => set.Add(comparable));
    }

    public static bool GroupByBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        return enumerable.GroupBy(value => value).Any(group => group.Count() > 1);
    }

    public static bool DistinctBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        return enumerable.Distinct().Count() != enumerable.Count();
    }

    public static bool LinqToHashSetBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        return enumerable.ToHashSet().Count() != enumerable.Count();
    }

    public static bool HashSetOnEnumerableCreatedBased<T>(IEnumerable<T> enumerable) where T : IComparable
    {
        return new HashSet<T>(enumerable).Count != enumerable.Count();
    }
}