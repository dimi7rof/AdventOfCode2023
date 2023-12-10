namespace AOC2023a;

public static class Day04
{
    public static void Part1()
    {
        var sum = 0.0;
        var input = File.ReadAllLines("..\\..\\..\\inputDay04.txt");
        var input0 = File.ReadAllLines("..\\..\\..\\exampleDay04.txt"); //12

        foreach (var line in input)
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
}