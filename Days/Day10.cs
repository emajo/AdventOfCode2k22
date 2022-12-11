using System.Collections.Generic;

class Day10
{
    public static int PartOne()
    {
        var sr = new StreamReader("inputs/day10.txt");

        var commands = new Dictionary<string, Dictionary<string, int>>()
        {
            { "addx", new Dictionary<string, int>{
                        { "cycles", 2 },
                        { "multiplier", 1 }
                    }
            },
            { "noop", new Dictionary<string, int>{
                        { "cycles", 1 },
                        { "multiplier", 0 }
                }
            }
        };

        int[] cyclesToAdd = new int[] { 20, 60, 100, 140, 180, 220 };

        int cyclesCount = 1;
        int total = 1;

        int cyclesTotal = 0;

        while (!sr.EndOfStream)
        {
            var splittedLine = sr.ReadLine().Split(' ');
            
            string cmd = splittedLine[0];

            for(int i = 0; i < commands[cmd]["cycles"]; i++)
            {
                if(commands[cmd]["multiplier"] != 0 && i == commands[cmd]["cycles"] - 1)
                {
                    total += Convert.ToInt32(splittedLine[1]) * commands[cmd]["multiplier"];
                }
                cyclesCount++;
                if (cyclesToAdd.Contains(cyclesCount)) 
                    cyclesTotal += cyclesCount * total;
            }
        }
        sr.Close();
        return cyclesTotal;
    }
    public static void PartTwo()
    {
        var sr = new StreamReader("inputs/day10.txt");

        var commands = new Dictionary<string, Dictionary<string, int>>()
        {
            { "addx", new Dictionary<string, int>{
                        { "cycles", 2 },
                        { "multiplier", 1 }
                    }
            },
            { "noop", new Dictionary<string, int>{
                        { "cycles", 1 },
                        { "multiplier", 0 }
                }
            }
        };

        int[] cyclesToAdd = new int[] { 20, 60, 100, 140, 180, 220 };

        int cyclesCount = 1;
        int total = 1;

        while (!sr.EndOfStream)
        {
            var splittedLine = sr.ReadLine().Split(' ');

            string cmd = splittedLine[0];

            for (int i = 0; i < commands[cmd]["cycles"]; i++)
            {
                int x = (cyclesCount - 1) % 40;
                if (x == 0) Console.Write('\n');
                if (Math.Abs(total - x) <= 1) Console.Write("#");
                else Console.Write(" ");

                if (commands[cmd]["multiplier"] != 0 && i == commands[cmd]["cycles"] - 1)
                {
                    total += Convert.ToInt32(splittedLine[1]) * commands[cmd]["multiplier"];
                }
                cyclesCount++;
            }
        }
        sr.Close();
    }

}
