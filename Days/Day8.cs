class Day8
{
    public static int PartOne()
    {
        var sr = new StreamReader("inputs/day8.txt");
        int currentLine = 0;

        var matrix = new List<List<int>>();

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                if(currentLine == 0)
                {
                    matrix.Add(new List<int>());
                }
                matrix[i].Add(line[i] - '0');
            }
            currentLine++;

        }
        sr.Close();

        int visibleThrees = 0;

        int[] maxLeftY = matrix[0].ToArray();
        List<int> maxTopX = new List<int>();

        for (int y = 0; y < matrix[0].Count - 1; y++)
        {
            for(int x = 1; x < matrix.Count - 1; x++)
            {
                bool isVisible = false;
                if (y == 0)
                {
                    maxTopX.Add(matrix[x][y]);
                    continue;
                }
                // check left
                if (matrix[x][y] > maxLeftY[y])
                {
                    isVisible = true;
                    maxLeftY[y] = matrix[x][y];
                }
                // check up
                if (matrix[x][y] > maxTopX[x - 1])
                {
                    isVisible = true;
                    maxTopX[x - 1] = matrix[x][y];
                }

                if (isVisible == true)
                {
                    visibleThrees++;
                    continue;
                }

                // check down
                List<int> remaingY = matrix[x].GetRange(y + 1, matrix[x].Count - y - 1);
                if (matrix[x][y] > remaingY.Max())
                {
                    visibleThrees++;
                    continue;
                }

                // check right
                isVisible = true;
                for (int x2 = x + 1; x2 < matrix.Count; x2++)
                {
                    if (matrix[x2][y] >= matrix[x][y])
                    {
                        isVisible = false;
                        break;
                    }
                }
                if (isVisible == true)
                {
                    visibleThrees++;
                }

            }

        }

        return visibleThrees + (matrix.Count + matrix[0].Count - 2) * 2 ;
    }

    public static int PartTwo()
    {
        var sr = new StreamReader("inputs/day8.txt");
        int currentLine = 0;

        var matrix = new List<List<int>>();

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (currentLine == 0)
                {
                    matrix.Add(new List<int>());
                }
                matrix[i].Add(line[i] - '0');
            }
            currentLine++;

        }
        sr.Close();

        int highestScenicScore = 0;

        for (int y = 1; y < matrix[0].Count - 1; y++)
        {
            for (int x = 1; x < matrix.Count - 1; x++)
            {
                int distance = 1;
                int tempDistance = 0;

                // check right
                for (int x2 = x + 1; x2 < matrix.Count; x2++)
                {
                    tempDistance++;
                    if (matrix[x2][y] >= matrix[x][y])
                    {
                        break;
                    }
                }

                distance *= tempDistance;
                tempDistance = 0;

                // check left
                for (int x2 = x - 1; x2 >= 0; x2--)
                {
                    tempDistance++;
                    if (matrix[x2][y] >= matrix[x][y])
                    {
                        break;
                    }
                }
                distance *= tempDistance;
                tempDistance = 0;

                // check up
                for (int y2 = y + 1; y2 < matrix[0].Count; y2++)
                {
                    tempDistance++;
                    if (matrix[x][y2] >= matrix[x][y])
                    {
                        break;
                    }
                }
                distance *= tempDistance;
                tempDistance = 0;

                // check down
                for (int y2 = y - 1; y2 >= 0; y2--)
                {
                    tempDistance++;
                    if (matrix[x][y2] >= matrix[x][y])
                    {
                        break;
                    }
                }
                distance *= tempDistance;
                highestScenicScore = Math.Max(highestScenicScore, distance);
            }

        }

        return highestScenicScore;
    }

}
