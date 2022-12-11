class Day2
{
    public static int PartOne()
    {
        var sr = new StreamReader("inputs/day2.txt");

        int total = 0;

        var shapesScore = new Dictionary<string, int>
        {
            {"A", 1},
            {"B", 2},
            {"C", 3},
        };

        var shapesMapping = new Dictionary<string, string>
        {
            {"X", "A"},
            {"Y", "B"},
            {"Z", "C"},
        };

        var wins = new Dictionary<string, string>
        {
            {"A", "B"},
            {"B", "C"},
            {"C", "A"},
        };

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            var splittedLine = line.Split(' ');
            var opponentMove = splittedLine[0];
            var myMove = shapesMapping[splittedLine[1]];

            total += shapesScore[myMove];

            if (opponentMove == myMove) total += 3;
            else if (wins[opponentMove] == myMove) total += 6;

        }
        sr.Close();
        return total;
    }

    public static int PartTwo()
    {
        var sr = new StreamReader("inputs/day2.txt");

        int total = 0;

        var shapesScore = new Dictionary<string, int>
        {
            {"A", 1},
            {"B", 2},
            {"C", 3},
        };

        var shapesMapping = new Dictionary<string, string>
        {
            {"X", "A"},
            {"Y", "B"},
            {"Z", "C"},
        };

        var wins = new Dictionary<string, string>
        {
            {"A", "B"},
            {"B", "C"},
            {"C", "A"},
        };

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            var splittedLine = line.Split(' ');
            var opponentMove = splittedLine[0];

            if (splittedLine[1] == "Z")
            {
                total += 6;
                total += shapesScore[wins[opponentMove]];
            } else if (splittedLine[1] == "Y")
            {
                total += 3;
                total += shapesScore[opponentMove];
            } else
            {
                total += shapesScore[wins.First(m => m.Value == opponentMove).Key];
            }

        }
        sr.Close();
        return total;
    }
}
