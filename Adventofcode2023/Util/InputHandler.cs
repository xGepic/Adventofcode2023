namespace Adventofcode2023.Util;

internal static class InputHandler
{
    public static List<string> GetContent(string fileName)
    {
        string path = $@"E:\Repos\Visual Studio\Adventofcode2023\Input\{fileName}";
        List<string> lines = [];
        try
        {
            lines.AddRange(File.ReadAllLines(path));
            return lines;
        }
        catch (Exception)
        {
            return [];
        }
    }
}
