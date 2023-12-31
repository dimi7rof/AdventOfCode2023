using System.Text.RegularExpressions;

namespace AOC2023a;

public static class Day03
{
    public static int Part01()
    {
        var example = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

        var part1 = 0;
        var part2 = 0;

        var input = File.ReadAllText("..\\..\\..\\inputDay03.txt");
       // input = example;
        var inputArray = input.Split(Environment.NewLine);

        string pattern = @"[\d]+";

        for (int row = 0; row < inputArray.Length; row++)
        {
            var line = inputArray[row];
            MatchCollection matches = Regex.Matches(line, pattern);
            var start = 0;

            foreach (Match match in matches.Cast<Match>())
            {
                var startIndex = line[start..].IndexOf(match.Value) + start;
                var endIndex = startIndex + match.Value.Length - 1;

                if (CheckAroud(inputArray, row, startIndex, match.Value))
                {
                    part1 += int.Parse(match.Value);
                }
                start = startIndex + match.Value.Length;
            }
        }

        return part1; // 537732
    }

    private static bool CheckAroud(string[] array, int row, int startIndex, string match)
    {
        var lenght = startIndex + match.Length >= array[row].Length ? match.Length : match.Length + 1;
        lenght = startIndex == 0 ? lenght : lenght + 1;
         var start = startIndex == 0 ? startIndex : startIndex - 1;
        var searchInList = new List<string>();

        if (row != 0)
        {
            searchInList.Add(array[row - 1].Substring(start, lenght));
        }
        if (row != array.Length - 1)
        {
            searchInList.Add(array[row + 1].Substring(start, lenght));
        }
        if (startIndex != 0)
        {
            searchInList.Add(array[row].Substring(start , 1));
        }
        if (startIndex + match.Length < array[row].Length)
        {
            searchInList.Add(array[row].Substring(start + lenght - 1, 1));
        }

        var res = searchInList.Any(x => x.ToCharArray().Any(x => x != '.' && !char.IsDigit(x)));

        return res;
    }
}