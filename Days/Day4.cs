class Day4
{
    public static int PartOne()
    {
        var sr = new StreamReader("inputs/day4.txt");
        int total = 0;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();

            var pairs = line.Split(',');
            var pair1 = pairs[0].Split('-');
            var pair2 = pairs[1].Split('-');

            int p11 = Convert.ToInt32(pair1[0]);
            int p12 = Convert.ToInt32(pair1[1]);
            int p21 = Convert.ToInt32(pair2[0]);
            int p22 = Convert.ToInt32(pair2[1]);


            if ((p11 >= p21 
                && p12 <= p22)
                ||
                (p11 <= p21
                && p12 >= p22)) total++;

        }
        sr.Close();
        return total;
    }

    public static int PartTwo()
    {
        var sr = new StreamReader("inputs/day4.txt");
        int total = 0;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();

            var pairs = line.Split(',');
            var pair1 = pairs[0].Split('-');
            var pair2 = pairs[1].Split('-');

            int p11 = Convert.ToInt32(pair1[0]);
            int p12 = Convert.ToInt32(pair1[1]);
            int p21 = Convert.ToInt32(pair2[0]);
            int p22 = Convert.ToInt32(pair2[1]);


            if (((p11 <= p21
                && p12 >= p21)
                ||
                (p11 <= p22
                && p12 >= p22))
               || ((p21 <= p11
                && p22 >= p11)
                || 
                (p21 <= p12
                && p22 >= p12))) total++;

        }
        sr.Close();
        return total;
    }
}
