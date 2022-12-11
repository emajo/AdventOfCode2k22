Console.WriteLine("Insert the day bro... ");
var day = Console.ReadLine();

switch (day)
{
    case "1":
        Console.WriteLine(Day1.PartOne()); 
        Console.WriteLine(Day1.PartTwo());
        break;
    case "2":
        Console.WriteLine(Day2.PartOne());
        Console.WriteLine(Day2.PartTwo());
        break;
    case "3":
        Console.WriteLine(Day3.PartOne());
        Console.WriteLine(Day3.PartTwo());
        break;
    case "4":
        Console.WriteLine(Day4.PartOne());
        Console.WriteLine(Day4.PartTwo());
        break;
    case "5":
        Console.WriteLine(Day5.PartOne());
        Console.WriteLine(Day5.PartTwo());
        break;
    case "6":
        Console.WriteLine(Day6.Part(4));
        Console.WriteLine(Day6.Part(14));
        break;
    case "7":
        Console.WriteLine(Day7.Part(false));
        Console.WriteLine(Day7.Part(true));
        break;
    case "8":
        Console.WriteLine(Day8.PartOne());
        Console.WriteLine(Day8.PartTwo());
        break;
    case "9":
        Console.WriteLine(Day9.Part(2));
        Console.WriteLine(Day9.Part(10));
        break;
    case "10":
        Console.WriteLine(Day10.PartOne());
        Day10.PartTwo();
        break;
    case "11":
        Console.WriteLine(Day11.Part());
        Console.WriteLine(Day11.Part(10000, 1));
        break;
    default:
        Console.WriteLine("Default");
        break;
}