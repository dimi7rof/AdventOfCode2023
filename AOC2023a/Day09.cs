namespace AOC2023a;

internal static class Day09
{
    public static int Part01()
    {
        var example = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

        var inputStringArr = File.ReadAllLines("..\\..\\..\\inputDay09.txt");
        var input =
            inputStringArr
            //example.Split(Environment.NewLine)
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(x => x
                .Select(y => int.Parse(y))
                .ToList())
            .ToList();

        var resultList = new List<int>();

        foreach (var row in input)
        {
            resultList.Add(NextRow(row));
        }

        return resultList.Sum();
        //1806615041
    }

    private static int NextRow(List<int> row)
    {
        var nextRow = new List<int>();

        for (int i = 1; i < row.Count; i++)
        {
            nextRow.Add(row[i] - row[i - 1]);
        }

        if (nextRow.Any(x => x != 0))
        {
            NextRow(nextRow);
            row.Add(row.Last() + nextRow.Last());
        }

        return row.Last();
    }
}
