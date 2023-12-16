namespace AOC2023a;

public static class Day02
{
    public static void Day02_1()
    {
        var sum = 0;
        var sum2 = 0;
        var input = File.ReadAllLines("..\\..\\..\\inputDay02.txt");
        var input0 = File.ReadAllLines("..\\..\\..\\exampleDay02.txt");

        foreach(var line in input0) //line = Game 1: 2 red, 2 green; 6 red, 3 green; 2 red, 1 green, 2 blue; 1 red
        {
            var game = line.Split(':').First(); // = Game 1
            var gameId = int.Parse(game.Split(' ').Last()); // = 1
            var sets = line.Split(':').Last().Split(';'); // = 2 red, 2 green; 6 red, 3 green; 2 red, 1 green, 2 blue; 1 red
            var possible = true;
            foreach(var set in sets) // set = 2 red, 2 green
            {
                var bags = set.Split(','); // = [2 red, 2 green]
                var blue = 0;
                var red = 0;
                var green = 0;
                var minBlue = int.MaxValue;
                var minRed = int.MaxValue;
                var minGreen = int.MaxValue;

                foreach(var bag in bags) // cube = 2 red
                {
                    var colorCount = bag.Trim().Split(' ');
                    var count = int.Parse(colorCount.First()); // = 2
                    var color = colorCount.Last(); // = red
                    
                    if(color == "green")
                    {
                        green += count;
                        minGreen = count < minGreen ? count : minGreen;
                    }
                    if(color == "blue")
                    {
                        blue += count;
                        minBlue = count < minBlue ? count : minBlue;
                    }
                    if(color == "red")
                    {
                        red += count;
                        minRed = count < minRed ? count : minRed;
                    }
                }
                minBlue = minBlue == int.MaxValue ? 1 : minBlue;
                minGreen = minGreen == int.MaxValue ? 1 : minGreen;
                minRed = minRed == int.MaxValue ? 1 : minRed;
                sum2 += (minBlue * minGreen * minRed);
                //only 12 red cubes, 13 green cubes, and 14 blue cubes.
                if(red > 12 || green > 13 || blue > 14)
                {
                    possible = false;
                    break;
                }
            }
            if(possible)
            {
                sum += gameId;
            }
            
        }
        System.Console.WriteLine(sum);
        System.Console.WriteLine(sum2);
    }
}