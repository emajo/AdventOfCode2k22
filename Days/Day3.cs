class Day3
{
    public static int PartOne()
    {
        var sr = new StreamReader("inputs/day3.txt");
        int total = 0;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var firstHalf = line.Substring(0, line.Length / 2).ToList();
            var secondHalf = line.Substring(line.Length / 2).ToList();

            var common = firstHalf.Intersect(secondHalf);

            foreach (char c in common)
            {
                if(c < 'a')
                {
                    total += (int)c - (int)'A' + 1 + 26; 
                } else
                {
                    total += (int)c - (int)'a' + 1;
                }
               
            }
        }
        sr.Close();
        return total;
    }

    public static int PartTwo()
    {
        var sr = new StreamReader("inputs/day3.txt");
        int total = 0;
        int counter = 0;
        IEnumerable<char> commonChars = new List<char>();

        while (!sr.EndOfStream)
        {
            counter++;

            List<char> actualLine = sr.ReadLine().ToList();

            if (counter > 1) commonChars = commonChars.Intersect(actualLine);
            else commonChars = actualLine;

            if (counter == 3)
            {
                foreach (char c in commonChars)
                {
                    if (c < 'a')
                    {
                        total += (int)c - (int)'A' + 1 + 26;
                    }
                    else
                    {
                        total += (int)c - (int)'a' + 1;
                    }
                    counter = 0;
                }
            }
        }
        sr.Close();
        return total;
    }
}
