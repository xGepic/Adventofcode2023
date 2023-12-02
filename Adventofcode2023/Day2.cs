using Adventofcode2023.Util;
using System.Text.RegularExpressions;

namespace Adventofcode2023;

public static partial class Day2
{
    public static int SolvePart1()
    {
        int iter = 1;
        int result = 0;
        foreach (var game in InputHandler.GetContent("day2.txt"))
        {
            if (MyRedRegex().Matches(game).Select(m => int.Parse(m.Groups[1].Value)).Any(num => num > 12) ||
                MyGreenRegex().Matches(game).Select(m => int.Parse(m.Groups[1].Value)).Any(num => num > 13) ||
                MyBlueRegex().Matches(game).Select(m => int.Parse(m.Groups[1].Value)).Any(num => num > 14))
            {
                iter++;
            }
            else
            {
                result += iter;
                iter++;
            }
        }
        return result;
    }
    public static int SolvePart2()
    {
        int result = 0;
        foreach (var game in InputHandler.GetContent("day2.txt"))
        {
            var maxBlueNumber = MyBlueRegex().Matches(game).Select(m => int.Parse(m.Groups[1].Value)).DefaultIfEmpty(0).Max();
            var maxGreenNumber = MyGreenRegex().Matches(game).Select(m => int.Parse(m.Groups[1].Value)).DefaultIfEmpty(0).Max();
            var maxRedNumber = MyRedRegex().Matches(game).Select(m => int.Parse(m.Groups[1].Value)).DefaultIfEmpty(0).Max();
            result += maxBlueNumber * maxGreenNumber * maxRedNumber;
        }
        return result;
    }
    [GeneratedRegex(@"\b(\d+)\sblue\b")]
    private static partial Regex MyBlueRegex();
    [GeneratedRegex(@"\b(\d+)\sgreen\b")]
    private static partial Regex MyGreenRegex();
    [GeneratedRegex(@"\b(\d+)\sred\b")]
    private static partial Regex MyRedRegex();
}
