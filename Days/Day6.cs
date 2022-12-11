using System;

class Day6
{
    public static int Part(int differentChars)
    {
        var sr = new StreamReader("inputs/day6.txt");
        string line = sr.ReadLine();
        var lastDouble = -differentChars;

        for (int index = 0; index < line.Length; index++)
        {
            var found = true;
            var currChar = line[index];
            for (int i = 1; i <= differentChars; i++)
            {
                if (i > index)
                {
                    found = false;
                    break;
                }
                if (currChar == line[index - i])
                {
                    if(index - i > lastDouble) lastDouble = index - i;
                    found = false;
                    break;
                }
                if (index < lastDouble + differentChars)
                {
                    found = false;
                    continue;
                }
            }
            if (found)
            {
                sr.Close();
                return index + 1;
            }

        }
        sr.Close();
        return 0;
    }

}
