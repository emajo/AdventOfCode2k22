using System.Net.Mail;

class Day5
{
    public static string PartOne()
    {
        var sr = new StreamReader("inputs/day5.txt");
        bool moves = false;
        int lineCount = 0;
        var matrix = new List<List<string>>();

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();

            if (moves)
            {
                var splittedLine = line.Split(' ');
                int n = Convert.ToInt32(splittedLine[1]);
                int from = Convert.ToInt32(splittedLine[3]) - 1;
                int to = Convert.ToInt32(splittedLine[5]) - 1;

                for (int i = 0; i < n; i++)
                {
                    matrix[to].Add(matrix[from].Last());
                    matrix[from].RemoveAt(matrix[from].Count - 1);
                }
            }

            if(line == "") moves = true;

            if (!moves)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if(i % 4 == 1 && !char.IsDigit(line[i]))
                    {
                        if(lineCount == 0)
                        {
                            matrix.Add(new List<string>());
                        }
                        if(line[i] != ' ') matrix[(i - 1) / 4].Insert(0, line[i].ToString());
                    }
                }
                lineCount++;
            }

        }
        sr.Close();
        return string.Join("", matrix.Select(l => l.Last()).ToArray());
    }

    public static string PartTwo()
    {
        var sr = new StreamReader("inputs/day5.txt");
        bool moves = false;
        int lineCount = 0;
        var matrix = new List<List<string>>();

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();

            if (moves)
            {
                var splittedLine = line.Split(' ');
                int n = Convert.ToInt32(splittedLine[1]);
                int from = Convert.ToInt32(splittedLine[3]) - 1;
                int to = Convert.ToInt32(splittedLine[5]) - 1;
                var tempList = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    tempList.Insert(0, matrix[from].Last());
                    matrix[from].RemoveAt(matrix[from].Count - 1);
                }
                matrix[to].AddRange(tempList);
            }

            if (line == "") moves = true;

            if (!moves)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (i % 4 == 1 && !char.IsDigit(line[i]))
                    {
                        if (lineCount == 0)
                        {
                            matrix.Add(new List<string>());
                        }
                        if (line[i] != ' ') matrix[(i - 1) / 4].Insert(0, line[i].ToString());
                    }
                }
                lineCount++;
            }

        }
        sr.Close();
        return string.Join("", matrix.Select(l => l.Last()).ToArray());
    }

}
