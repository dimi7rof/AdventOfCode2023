using System.Text.RegularExpressions;

namespace AOC2023a;

public static class Day01
{
    public static void Day01_2()
    {
        var sum =0;
        var input = File.ReadAllLines("..\\..\\..\\inputDay01.txt");
        var input2 = new List<string>() {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        var digitAsString = new Dictionary<string, int>() {
            { "one", 1 },
            { "two", 2 },
            { "three", 3},
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };
        foreach (var line in input2) 
        {
            var newLine = line;
            foreach (var (key,value) in digitAsString)
            {
                if(line.Contains(key))
                {
                    //newLine = line.Replace(key, value);
                    //line.Remove(line.IndexOf(key)).Replace(key, value);
                }
            }
            //if(line.Contains(test.Any()))
            var digits = line.Where(Char.IsDigit).ToArray();
            if(digits.Length == 1) 
            {
                sum +=Convert.ToInt32(new string([digits[0],digits[0]]));
            }
            if(digits.Length >= 2) 
            {
                sum += Convert.ToInt32(new string([digits[0],digits[^1]]));
            }
        }
    }

    public static void Day01_1()
    {
        var sum = 0;
        var input = File.ReadAllLines("..\\..\\..\\inputDay01.txt");

        foreach (var line in input) 
        {
            var digits = line.Where(Char.IsDigit).ToArray();
            if(digits.Length == 1) 
            {
                sum +=Convert.ToInt32(new string([digits[0],digits[0]]));
            }
            if(digits.Length >= 2) 
            {
                sum += Convert.ToInt32(new string([digits[0],digits[^1]]));
            }
        }
        Console.WriteLine(sum);
    }
}

