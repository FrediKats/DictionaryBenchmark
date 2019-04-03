using System;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace DictionaryBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<Bench>();
            Console.ReadLine();
        }
    }
}
