using BenchmarkDotNet.Attributes;
using MethodTimer;

namespace Duplication.Recognition.Benchmark;

[MemoryDiagnoser]
public class Dupa123
{
    
    private static List<(int lol1, int lol2, int lol3)> _collection;

    [Params(2, 10, 30, 300)] public int Size { get; set; }
    public double DuplicationIndex { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _collection = Creatr();
    }

    public List<(int lol1, int lol2, int lol3)> Creatr()
    {
        var change = (int)new Random(1).NextInt64();
        
        var test = new List<(int lol1, int lol2, int lol3)>();
        for (int i = 0; i < Size; i++)
        {
            if (i % 3 == 0)
            {
                test.Add((i, i, change));
                test.Add((i, i, i + 1 + change));
                test.Add((i, i, i + 2 + change));
                continue;
            }

            test.Add((i, i + 1 + change, i + 2 + change));
        }

        return test;
    }

    [Benchmark]
    public List<(int lol1, int lol2, int lol3)> Test1()
    {

        var test = _collection;
        var resellerCustomerIds = test.GroupBy(x => new { ResellerId = x.lol1, CustomerId = x.lol2 }).Distinct();
        foreach (var resellerCustomer in resellerCustomerIds)
        {
            var resellerCustomerSoftwareSubscriptions = test.Where(x => x.lol1 == resellerCustomer.Key.ResellerId && x.lol2 == resellerCustomer.Key.CustomerId).ToList();
        }

        return test;
    }

    [Benchmark]
    public List<(int lol1, int lol2, int lol3)> Test2()
    {
        var test = _collection;
        var dir = new Dictionary<(int, int), List<(int, int, int)>>();

        foreach (var resellerCustomer in test)
        {
            if (dir.ContainsKey((resellerCustomer.lol1, resellerCustomer.lol2)))
            {
                dir[(resellerCustomer.lol1, resellerCustomer.lol2)].Add((resellerCustomer));
                continue;
            }

            dir.Add((resellerCustomer.lol1, resellerCustomer.lol2), new List<(int, int, int)>() { resellerCustomer });
        }

        foreach (var pair in dir)
        {
            var key = pair.Key;
            foreach (var VARIABLE in pair.Value)
            {
                var value = VARIABLE;
            } 
        }

        return test;
    }


}