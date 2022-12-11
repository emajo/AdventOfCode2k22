class Day11
{
    public static long Part(int nRounds = 20, int divider = 3)
    {
        var sr = new StreamReader("inputs/day11.txt");
        var monkeys = new List<Monkey>();
        int monkeyIndex = 0;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine().Trim();
            if (line == "") continue;

            var splittedLine = line.Split(": ");
            var splittedOperation = splittedLine[0].Split(' ');

            if (splittedOperation[0] == "Monkey")
            {
                monkeyIndex = Convert.ToInt32(monkeys.Count);
                monkeys.Add(new Monkey());
                continue;
            }

            if (splittedLine[0] == "Starting items")
            {
                var items = splittedLine[1].Split(", ");
                foreach(var item in items)
                {
                    monkeys[monkeyIndex].Items.Add(Convert.ToInt32(item));
                }
                continue;
            }

            var splitedCommand = splittedLine[1].Split(' ');
            
            if (splittedLine[0] == "Operation")
            { 
                if (splitedCommand[3] == "*" && splitedCommand[4] == "old")
                {
                    monkeys[monkeyIndex].Operation = "^";
                    monkeys[monkeyIndex].Amount = 2;
                } else
                {
                    monkeys[monkeyIndex].Operation = splitedCommand[3];
                    monkeys[monkeyIndex].Amount = Convert.ToInt32(splitedCommand[4]);
                }
                continue;
            }

            if (splittedLine[0] == "Test")
            {
                monkeys[monkeyIndex].Test = Convert.ToInt32(splitedCommand[2]);
                continue;
            }

            if (splittedOperation[1] == "true")
            {
                monkeys[monkeyIndex].TestResTrue = Convert.ToInt32(splitedCommand[3]);
                continue;
            }

            if (splittedOperation[1] == "false")
            {
                monkeys[monkeyIndex].TestResFalse = Convert.ToInt32(splitedCommand[3]);
                continue;
            }

        }

        sr.Close();

        for(int r = 0; r < nRounds; r++)
        {
            if (r ==1)
            {
                Console.Write("");
            }
            foreach (var monkey in monkeys)
            {
                int initialMonkeyItemsCount = monkey.Items.Count();
                for (int i = 0; i < initialMonkeyItemsCount; i++)
                {
                    switch (monkey.Operation)
                    {
                        case "+":
                            monkey.Items[0] += monkey.Amount;
                            break;
                        case "*":
                            monkey.Items[0] *= monkey.Amount;
                            break;
                        case "^":
                            monkey.Items[0] = monkey.Items[0] * monkey.Items[0];
                            break;
                    }
                    long roundedNewItemVal;
                    if (divider != 1)
                    {
                        roundedNewItemVal =  monkey.Items[0] / divider;
                    } else
                    {
                        roundedNewItemVal = monkey.Items[0];
                        roundedNewItemVal %= monkeys.Aggregate(1, (a, monkey) => a * monkey.Test);
                    }
                    int newMonkeyIndex;
                    if (roundedNewItemVal % monkey.Test == 0)
                    {

                        newMonkeyIndex = monkey.TestResTrue;
                    } else
                    {
                        newMonkeyIndex = monkey.TestResFalse;
                    }
                    monkeys[newMonkeyIndex].Items.Add(roundedNewItemVal);
                    monkey.Items.RemoveAt(0);
                    monkey.InpectedTimes++;
                }
            }
        }
        Monkey[] top2 = monkeys.OrderByDescending(m => m.InpectedTimes).Take(2).ToArray();

        return top2[0].InpectedTimes * top2[1].InpectedTimes;

    }

}

class Monkey 
{ 
    public List<long> Items;
    public string Operation;
    public int Amount;
    public int Test;
    public int TestResTrue;
    public int TestResFalse;
    public long InpectedTimes;

    public Monkey()
    {
        Items = new List<long>();
    }
}