namespace AOC2023a;

public static class Day01
{
    public static int Part01()
    {
        var input = File.ReadAllLines("..\\..\\..\\inputDay01.txt");

        return CountDigits(input);
    }

    public static int Part02()
    {
        var input = File.ReadAllText("..\\..\\..\\inputDay01.txt");

        var repalced = input
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "thr3e")
            .Replace("four", "fo4r")
            .Replace("five", "fi5e")
            .Replace("six", "s6x")
            .Replace("seven", "se7en")
            .Replace("eight", "ei8ht")
            .Replace("nine", "n9ne");

        return CountDigits(repalced.Split(Environment.NewLine));
    }

    private static int CountDigits(string[] input)
    {
        var sum = 0;

        foreach (var line in input)
        {
            var digits = line.Where(Char.IsDigit).ToArray();
            sum += Convert.ToInt32(new string([digits[0], digits[^1]]));
        }

        return sum;
    }
}

