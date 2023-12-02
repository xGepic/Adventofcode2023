using Adventofcode2023.Util;
using System.Text;
using System.Text.RegularExpressions;

namespace Adventofcode2023;

public static partial class Day1
{
    public static int SolvePart1()
    {
        int result = 0;
        foreach (var item in InputHandler.GetContent("day1.txt"))
        {
            string firstNumber = "";
            string lastNumber = "";
            MatchCollection matches = MyRegex().Matches(item);
            firstNumber = matches[0].Value;
            if (matches.Count > 1)
            {
                lastNumber = matches.Last().Value;
            }
            else
            {
                lastNumber = firstNumber;
            }
            result += int.Parse(firstNumber) * 10 + int.Parse(lastNumber);
        }
        return result;
    }
    public static int SolvePart2()
    {
        int result = 0;
        foreach (var item in InputHandler.GetContent("day1.txt"))
        {
            string firstNumber = "";
            string lastNumber = "";
            StringBuilder stringBuilder = new(item);
            stringBuilder.Replace("one", "o1e");
            stringBuilder.Replace("two", "t2o");
            stringBuilder.Replace("three", "t3e");
            stringBuilder.Replace("four", "f4r");
            stringBuilder.Replace("five", "f5e");
            stringBuilder.Replace("six", "s6x");
            stringBuilder.Replace("seven", "s7n");
            stringBuilder.Replace("eight", "e8t");
            stringBuilder.Replace("nine", "n9e");
            var myString = stringBuilder.ToString();
            MatchCollection matches = MyRegex().Matches(myString);
            firstNumber = matches[0].Value;
            if (matches.Count > 1)
            {
                lastNumber = matches.Last().Value;
            }
            else
            {
                lastNumber = firstNumber;
            }
            result += int.Parse(firstNumber) * 10 + int.Parse(lastNumber);
        }
        return result;
    }
    [GeneratedRegex(@"\d")]
    private static partial Regex MyRegex();
}
