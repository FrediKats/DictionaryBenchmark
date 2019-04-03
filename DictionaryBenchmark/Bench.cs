using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace DictionaryBenchmark
{
    [ClrJob, CoreJob]
    public class Bench
    {
        [Params(100_000, 1_000_000, 10_000_000)]
        public int ElementsCount;

        [IterationSetup]
        public void Setup()
        {
            _dict?.Clear();
            _dict = new Dictionary<int, int>();

            _cDict?.Clear();
            _cDict = new ConcurrentDictionary<int, int>();
        }

        private Dictionary<int, int> _dict;
        private ConcurrentDictionary<int, int> _cDict;

        [Benchmark]
        public void DictionaryWithLockTest()
        {
            for (Int32 i = 0; i < ElementsCount; i++)
            {
                lock (_dict)
                {
                    _dict.Add(i, i);
                }
            }
        }

        [Benchmark]
        public void ConcurrentDictionaryTest()
        {
            for (Int32 i = 0; i < ElementsCount; i++)
            {
                _cDict.TryAdd(i, i);
            }
        }
    }
}