class Day1
{
    public static int PartOne()
    {
        var sr = new StreamReader(@"inputs/day1.txt");

        int highest = 0;
        int currentSum = 0;
        string line = string.Empty;

        while (line != null)
        {
            line = sr.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                if (currentSum > highest) highest = currentSum;
                currentSum = 0;
            }
            else
            {
                currentSum += Convert.ToInt32(line);
            }
        }
        sr.Close();
        return highest;
    }

    public static int PartTwo()
    {
        var sr = new StreamReader("inputs/day1.txt");

        int[] topThree = new int[] { 0, 0, 0 };
        int currentSum = 0;
        string line = string.Empty;

        while (line != null)
        {
            line = sr.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                if (currentSum > topThree[0]) topThree[0] = currentSum;
                Array.Sort(topThree);
                currentSum = 0;
            }
            else
            {
                currentSum += Convert.ToInt32(line);
            }
        }
        sr.Close();
        return topThree.Sum();
    }
}
