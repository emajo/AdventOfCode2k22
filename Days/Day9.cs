using System.Runtime.Serialization.Formatters;

class Day9
{
    public static int Part(int size)
    {
        var sr = new StreamReader("inputs/day9.txt");

        Rope rope = new Rope(size);

        while (!sr.EndOfStream)
        {
            var splittedLine = sr.ReadLine().Split(' ');
            string move = splittedLine[0];
            int steps = Convert.ToInt32(splittedLine[1]);

            rope.MoveHead(move, steps);
        }
        sr.Close();
        return rope.VisitedPositions.Count();
    }

}


class RopeKnot
{
    public int X;
    public int Y;

    public RopeKnot()
    {
        X = 0;
        Y = 0;
    }

    public void Move(string move, int steps)
    {
        switch (move)
        {
            case "U":
                Y += steps;
                break;
            case "D":
                Y -= steps;
                break;
            case "R":
                X += steps;
                break;
            case "L":
                X -= steps;
                break;
        }
    }
}

class Rope
{
    public RopeKnot[] knots;
    public List<string> VisitedPositions { get; set; }
    public Rope(int size)
    {
        knots = new RopeKnot[size];
        for(int kn = 0; kn < size; kn++)
        {
            knots[kn] = new RopeKnot();
        }
        VisitedPositions = new List<string> { "0:0" };
    }

    public void MoveHead(string move, int steps)
    {
        for (int i = 0; i < steps ; i++)
        {
            knots[0].Move(move, 1);

            for (int t = 1; t < knots.Count(); t++)
            {
                var head = knots[t - 1];
                var tail = knots[t];
                int dx = head.X - tail.X;
                int dy = head.Y - tail.Y;

                if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
                {
                    tail.X += Math.Sign(dx);
                    tail.Y += Math.Sign(dy);
                }
            }
            string pos = string.Format("{0}:{1}", knots[knots.Count() - 1].X, knots[knots.Count() - 1].Y);
            if(!VisitedPositions.Contains(pos)) VisitedPositions.Add(pos);

        }
    }
}