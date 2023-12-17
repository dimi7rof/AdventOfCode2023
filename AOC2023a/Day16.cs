using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;

namespace AOC2023a;

public static class Day16
{
    private static char[,] _printArray;
    private static char[,] _array;
    private static long _steps;
    private static HashSet<(char, int, int)> _stack = new();
    private static Stopwatch _sw = new Stopwatch();

    public static async Task Part01()
    {
        _sw.Start();
        var input = @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";

        input = File.ReadAllText("..\\..\\..\\inputDay16.txt");
        _array = FillArrayFromMultilineString(input);
        _printArray = new char[_array.GetLength(0), _array.GetLength(1)];
        Array.Copy(_array, _printArray, _array.GetLength(0) * _array.GetLength(1));

        await Move(_array, 0, 0, 'R');

        PrintArray(_printArray, 0, 0);
    }

    private static async Task Move(char[,] array, int y, int x, char direction)
    {
        while (x >= 0 && y >= 0 && x < array.GetLength(1) && y < array.GetLength(0))
        {
            if (_stack.Contains((direction, x, y))) { return; }
            _stack.Add((direction, x, y));
            _steps++;
            _printArray[y, x] = '#';
            //PrintArray(_printArray, y, x);
            var currPos = array[y, x];

            if (direction == 'R')
            {
                if (currPos == '.' || currPos == '-') { x++; }
                else if (currPos == '\\') { direction = 'D'; y++; }
                else if (currPos == '/') { direction = 'U'; y--; }
                else if (currPos == '|')
                {
                    await Move(array, y++, x, 'D');
                    direction = 'U';
                    y--;
                }
            }
            else if (direction == 'D')
            {
                if (currPos == '.' || currPos == '|') { y++; }
                else if (currPos == '\\') { direction = 'R'; x++; }
                else if (currPos == '/') { direction = 'L'; x--; }
                else if (currPos == '-')
                {
                    await Move(array, y, x--, 'L');
                    direction = 'R';
                    x++;
                }
            }
            else if (direction == 'L')
            {
                if (currPos == '.' || currPos == '-') { x--; }
                else if (currPos == '\\') { direction = 'U'; y--; }
                else if (currPos == '/') { direction = 'D'; y++; }
                else if (currPos == '|')
                {
                    await Move(array, y++, x, 'D');
                    direction = 'U';
                    y--;
                }
            }
            else if (direction == 'U')
            {
                if (currPos == '.' || currPos == '|') { y--; }
                else if (currPos == '\\') { direction = 'L'; x--; }
                else if (currPos == '/') { direction = 'R'; x++; }
                else if (currPos == '-')
                {
                    await Move(array, y, x--, 'L');
                    direction = 'R';
                    x++;
                }
            }
        }
        _stack.Remove(_stack.Last());

        return;
    }

    private static char[,] FillArrayFromMultilineString(string multilineString)
    {
        string[] lines = multilineString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        int rows = lines.Length;
        int columns = lines[0].Length;
        char[,] charArray = new char[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                charArray[i, j] = lines[i][j];
            }
        }

        return charArray;
    }

    private static void PrintArray(char[,] charArray, int x, int y)
    {
        Console.Clear();
        //int rows = charArray.GetLength(0);
        //int columns = charArray.GetLength(1);

        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < columns; j++)
        //    {
        //        var currentChar = charArray[i, j];
        //        if (_array[i, j] != '.')
        //        {
        //            currentChar = _array[i, j];
        //        }
        //        if (y == j && x == i)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.Write(currentChar + " ");
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        else
        //        {
        //            Console.Write(currentChar + " ");
        //        }
        //    }
        //    Console.WriteLine();
        //}
        Console.WriteLine($"Steps={_steps}");
        Console.WriteLine("Result = " + charArray.Cast<char>().Count(c => c == '#'));
    }
}
