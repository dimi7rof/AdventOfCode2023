namespace AOC2023a;

public static class Day03
{
    public static void Part1()
    {
        var sum = 0;
        var input = File.ReadAllLines("..\\..\\..\\inputDay03.txt");
        var input0 = File.ReadAllLines("..\\..\\..\\exampleDay03.txt"); //4361

        var arr = input0.Select(x => x.ToArray()).ToArray();

        for (var row = 0; row < arr.Length; row++)
        {
            int digit = 0;
            for (var ch = arr[row].Length - 1; ch >= 0; ch--)
            {
                var currentChar = arr[row][ch];
                if(int.TryParse(currentChar.ToString(), out int result))
                {
                    var multiplier = digit == 0 ? 1 : 10^digit.ToString().Length;
                    digit = result * multiplier;   
                }
                else
                {
                    sum += digit;
                }
                
                
            }
        }




    }
    private static int GetDigit(char[][] arr, int row, int ch)
    {
        int digit = 0;
        var currentChar = arr[row][ch];
        if(int.TryParse(currentChar.ToString(), out int result))
        {
            digit = digit*10 + GetDigit(arr, row, ch + 1);            
        }
        return digit;
    }
}