
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

    public static int Part02()
    {
        var input = File.ReadAllText("..\\..\\..\\inputDay08.txt");

        var direction = input.Split(Environment.NewLine)[0].ToCharArray();

        var network = input
            .Replace("(", "")
            .Replace(")", "")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1)
            .ToDictionary(x => x.Split(" = ")[0], x => x.Split(" = ")[1].Split(", "));

        var stepsList = new List<int>();
        var starting = network.Where(x => x.Key.EndsWith('A')).ToDictionary();

        var steps = 0;
        
        var currDirectionIndex = 0;
        while ( true )
        {
            var list = new List<string>(); 
            foreach (var (item, values) in starting)
            {
                var current = item;

                while (!current.EndsWith('Z'))
                {
                    currDirectionIndex = currDirectionIndex > direction.Length - 1 ? 0 : currDirectionIndex;
                    current = direction[currDirectionIndex] == 'L' ? network[current][0] : network[current][1];
                    steps++;
                    currDirectionIndex++;
                }
                stepsList.Add(steps);
            }
            if (list.All(x => x.EndsWith('Z')))
            {

            }
        }
        



        return stepsList.Max();
    }
}
