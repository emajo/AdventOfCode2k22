using System;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

class Day13
{
    public static string PartOne()
    {
        var sr = new StreamReader("inputs/day13.txt");

        var index = 0;
        var total = 0;
        while (!sr.EndOfStream)
        {
            index++;

            var left = sr.ReadLine();
            var right = sr.ReadLine();

            var leftList = DataType.BuildFromString(left);
            var rightList = DataType.BuildFromString(right);

            //Console.WriteLine(index);
            if (leftList.IsLower(rightList) == 1)
            {
                total += index;
            }
            
           sr.ReadLine();

        }
        sr.Close();
        return total.ToString();
    }

    public static string PartTwo()
    {
        var sr = new StreamReader("inputs/day13.txt");

        var packets = new List<string>();

        var insertPacket = (string line) =>
        {
            int index = 0;
            for (var i = 0; i < packets.Count; i++)
            {
                if (DataType.BuildFromString(packets[i]).IsLower(DataType.BuildFromString(line)) == 1)
                {
                    index = i + 1;
                }
                else
                {
                    break;
                }
            }
            packets.Insert(index, line);
            return index + 1;
        };

        while (!sr.EndOfStream)
        {

            var line = sr.ReadLine();
            if (line == null || line == "") continue;

            insertPacket(line);

        }
        sr.Close();

        int first = insertPacket("[[2]]");
        int second = insertPacket("[[6]]");

        return (first * second).ToString();
    }

}

class DataType
{
    public DataType? parent;
    // Worst decision of my life to use a queue here
    public Queue<object> data; // object will be int or DataType

    public DataType(DataType? parentDataType)
    {
        parent = parentDataType;
        data = new Queue<object>();
    }

    public static DataType BuildFromString(string input)
    {
        var dt = new DataType(null);
        var q = new Queue<char>(input);
        buildFromQueueWithCache(q, dt);
        return dt;
    }

    private static void buildFromQueueWithCache(Queue<char> input, DataType current)
    {
        if (input.Count == 0) return;

        var c = input.Dequeue();

        if (c == ',')
        {
            buildFromQueueWithCache(input, current);
        } else if (c == '[')
        {
            var newData = new DataType(current);
            buildFromQueueWithCache(input, newData);
        } else if (c == ']')
        {
            if(current.parent != null) //always true, here only to not upset the compiler
            {
                current.parent.data.Enqueue(current);
                buildFromQueueWithCache(input, current.parent);
            }
        } else if (c == 'x')
        {
            current.data.Enqueue(10);
            buildFromQueueWithCache(input, current);
        }
        else
        {
            current.data.Enqueue(Convert.ToInt32(c.ToString()));
            buildFromQueueWithCache(input, current);
        }
       
    }
    public int IsLower(DataType compared)
    {
        if (data.Count == 0 && compared.data.Count == 0) return 0;
        if (data.Count == 0) return 1;
        if (compared.data.Count == 0) return -1;

        var left = data.Dequeue();
        var right = compared.data.Dequeue();
        //Console.WriteLine("Compare " + left.ToString() + " vs " + right.ToString());

        if(right is DataType && left is DataType)
        {
            var isLower = ((DataType)left).IsLower((DataType)right);
            if (isLower == 0)
            {
                return IsLower(compared);
            }
            return isLower;

        } else if(right is int && left is int)
        {
            if (Convert.ToInt32(left) < Convert.ToInt32(right))
            {
                return 1; 
            } else if (Convert.ToInt32(left) > Convert.ToInt32(right))
            {
                return -1;
            }
            return IsLower(compared);
        } else
        {
            if(left is DataType)
            {
                var q = new Queue<object>();
                q.Enqueue(right);
                var dt = new DataType(null);
                dt.data = q;
                var isLower = ((DataType)left).IsLower(dt);
                if (isLower == 0)
                {
                    return IsLower(compared);
                }
                return isLower;
            } else
            {
                var q = new Queue<object>();
                q.Enqueue(left);
                var dt = new DataType(null);
                dt.data = q;
                var isLower = dt.IsLower((DataType)right);
                if (isLower == 0)
                {
                    return IsLower(compared);
                }
                return isLower;
            }
        }
    }
}
