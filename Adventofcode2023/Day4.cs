using Adventofcode2023.Util;

namespace Adventofcode2023;

public static class Day4
{
    private static readonly char[] separator = [' '];
    public static int SolvePart1()
    {
        int result = 0;
        foreach (var item in InputHandler.GetContent("day4.txt"))
        {
            string[] parts = item[(item.IndexOf(':') + 1)..].Trim().Split('|');
            result += (int)Math.Round(Math.Pow(2, parts[0].Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                .Count(parts[1].Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList().Contains) - 1));
        }
        return result;
    }
    public static int SolvePart2()
    {
        int iter = 1;
        Dictionary<int, int> gamesWithMatches = [];
        Dictionary<int, int> finalCardCount = [];
        foreach (var item in InputHandler.GetContent("day4.txt"))
        {
            string[] parts = item[(item.IndexOf(':') + 1)..].Trim().Split('|');
            gamesWithMatches.Add(iter, parts[0].Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                .Count(parts[1].Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList().Contains));
            iter++;
        }
        foreach (var game in gamesWithMatches)
        {
            finalCardCount.Add(game.Key, 1);
        }
        foreach (var game in gamesWithMatches)
        {
            foreach (var nextGame in gamesWithMatches.Where(x => x.Key > game.Key && x.Key <= game.Key + game.Value))
            {
                finalCardCount[nextGame.Key] += finalCardCount[game.Key];
            }
        }
        return finalCardCount.Sum(x => x.Value);
    }
}
