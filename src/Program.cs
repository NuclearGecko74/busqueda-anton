using busqueda_anton.src;
using busqueda_anton.src.DataStructures;
using busqueda_anton.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busqueda_anton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = { 10_000, 50_000, 100_000 };
            int iterations = 1_000;                 // 🔸 repeticiones por prueba
            var rand = new Random();
            var algoNames = new[] { "Linear", "Binary", "Hash" };

            foreach (var size in sizes)
            {
                var data = Enumerable.Range(0, size).Select(_ => rand.Next()).ToList();
                var sorted = new List<int>(data); sorted.Sort();

                var ht = new HashTable();
                foreach (var v in data) ht.Set(v.ToString(), v);

                int target = data[rand.Next(size)];
                string tKey = target.ToString();

                // 🔸 calentamiento ligero (compilación JIT)
                Algorithms.LinearSearch(data, target);
                Algorithms.BinarySearch(sorted, target);
                ht.Get(tKey);

                Console.WriteLine($"\nTamaño: {size:N0}  |  Iteraciones: {iterations:N0}");
                Console.WriteLine($"{"Algoritmo",-10} | {"Media (ms)",12}");
                Console.WriteLine(new string('-', 26));

                foreach (var name in algoNames)
                {
                    TimeSpan elapsed = Timer.Measure(() =>
                    {
                        for (int i = 0; i < iterations; i++)
                        {
                            switch (name)
                            {
                                case "Linear": Algorithms.LinearSearch(data, target); break;
                                case "Binary": Algorithms.BinarySearch(sorted, target); break;
                                case "Hash": ht.Get(tKey); break;
                            }
                        }
                    });

                    double avgMs = elapsed.TotalMilliseconds / iterations;
                    Console.WriteLine($"{name,-10} | {avgMs,12:N6}");
                }
            }
        }
    }
}
