using System;
using System.Reflection.PortableExecutable;

namespace AOC2023a;

public static class Day04
{
    private static string[] _input = File.ReadAllLines("..\\..\\..\\exampleDay04.txt");
    //private static string _input = "..\\..\\..\\inputDay04.txt";

    public static void Part1()
    {
        var sum = 0.0;

        foreach (var line in _input)
        {
            var numbers = line.Split(':')[^1];
            var winningNums = numbers.Split('|').First().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var mineNums = numbers.Split('|').Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var matching = winningNums.Intersect(mineNums).ToArray();
            var points = matching.Length == 1 ? 1 :
                matching.Length > 1 ? Math.Pow(2, (matching.Length - 1)) : 0;

            sum += points;

            Console.WriteLine(sum);
        }
    }
    public static void Part2()
    {
        var sum = _input.Length;        

        for (var i = 1; i <= _input.Length; i++)
        {
            var line = _input[i-1];
            var numbers = line.Split(':')[^1];
            var winningNums = numbers.Split('|').First().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var mineNums = numbers.Split('|').Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var matching = winningNums.Intersect(mineNums).ToArray().Length;
            sum += matching != 0 ? GetCopies(Enumerable.Range(i + 1, matching)) : 0;
            //sum += GetCopies(input0, Enumerable.Range(i + 1, matching));
        }

        Console.WriteLine(sum);
    }
    private static int GetCopies(IEnumerable<int> ints)
    {
        var sum = ints.Count();
        Console.WriteLine(string.Join(",", ints));
        foreach (var num in ints)
        {
            var numbers = num < _input.Length ? _input[num].Split(':')[^1] : string.Empty;
            var winningNums = numbers.Split('|').First().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var mineNums = numbers.Split('|').Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var matching = winningNums.Intersect(mineNums).ToArray().Length;
            sum += matching != 0 ? GetCopies(Enumerable.Range(num + 1, matching)) : 0;
        }
        Console.WriteLine(sum);
        return sum;
    }
}