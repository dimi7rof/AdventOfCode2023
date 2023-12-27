using System.Diagnostics;

namespace AOC2023a;

internal static class Day08
{
    public static int Part01()
    {
        var exampleStr = @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)";

        var input = File.ReadAllText("..\\..\\..\\inputDay08.txt");

        var direction = input.Split(Environment.NewLine)[0].ToCharArray();

        var network = input
            .Replace("(", "")
            .Replace(")", "")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1)
            .ToDictionary(x => x.Split(" = ")[0], x => x.Split(" = ")[1].Split(", "));

        var steps = 0;
        var current = "AAA";
        var currDirectionIndex = 0;

        while (current != "ZZZ")
        {
            currDirectionIndex = currDirectionIndex > direction.Length - 1 ? 0 : currDirectionIndex;
            current = direction[currDirectionIndex] == 'L' ? network[current][0] : network[current][1];
            steps++;
            currDirectionIndex++;
        }

        return steps;
    }

    public static double Part02()
    {
        var sw = new Stopwatch();
        sw.Start();
        var input = File.ReadAllText("..\\..\\..\\inputDay08.txt");

        var direction = input.Split(Environment.NewLine)[0].ToCharArray();

        var network = input
            .Replace("(", "")
            .Replace(")", "")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1)
            .ToDictionary(x => x.Split(" = ")[0], x => x.Split(" = ")[1].Split(", "));

        var starting = network.Where(x => x.Key.EndsWith('A')).Select(x => x.Key).ToList();
        var listOfSteps = new List<int>();
        
        Parallel.ForEach(starting, (start) =>
        {
            var index = 0;
            var current = start;
            var step = 0;
            while (true)
            {
                index = index > direction.Length - 1 ? 0 : index;
                current = direction[index] == 'L' ? network[current][0] : network[current][1];
                step++;
                index++;
                if (current.EndsWith('Z'))
                {
                    listOfSteps.Add(step);
                    break;
                }
            }            
        });

        Console.WriteLine(string.Join(", ", listOfSteps));
        double minSteps = listOfSteps.Min();

        while (true)
        {
            var success = listOfSteps
                .Select(x => minSteps / x)
                .All(x => Math.Floor(x) == Math.Ceiling(x));

            if (success)
            {
                break;
            }
            minSteps += listOfSteps.Min();
        }

        Console.WriteLine($"{minSteps:F0}");
        sw.Stop();
        Console.WriteLine(sw.Elapsed);

        return minSteps;
    }
}
//10 241 191 004 509
