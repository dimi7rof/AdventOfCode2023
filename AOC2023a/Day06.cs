namespace AOC2023a;

internal static class Day06
{
    public static int Part01()
    {        
        var example = new List<(int time, int distance)>()
        {
            ( 7, 9 ),
            (15, 40),
            (30, 200)
        };

        var input = new List<(int time, int distance)>()
        {
            ( 56, 334 ),
            ( 71, 1135),
            ( 79, 1350),
            ( 99, 2430)
        };

        var result = new List<int>();

        foreach ( var (time, distance) in input)
        {
            var current = 0;

            for (int i = 0; i < time; i++)
            {
                current = (i * (time - i)) > distance ? current += 1 : current;                
            }
            result.Add(current);
        }
        Console.WriteLine(result.Aggregate((x, y) => x * y));

        return result.Aggregate((x, y) => x * y);
    }

    public static int Part02()
    {
        var example = (75130, 940200);
        var inp = @"Time:        56     71     79     99
Distance:   334   1135   1350   2430";

        var time = long.Parse(inp.Split(Environment.NewLine)[0].Split(":")[^1].Trim().Replace(" ", ""));
        var distance = long.Parse(inp.Split(Environment.NewLine)[^1].Split(":")[^1].Trim().Replace(" ", ""));
        var result = 0;

        for (int i = 14; i < time - 14; i++)
        {
            result = (i * (time - i)) > distance ? result += 1 : result;
        }

        return result;
    }
}
