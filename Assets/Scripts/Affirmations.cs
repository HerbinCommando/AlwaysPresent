using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Loader
{
    public static List<string> statements = new();
    public static Dictionary<int, List<string>> sets = new();
    public static List<string> steps = new();

    public static string NextStatement => statements.Random();
    public static string NextGenerated => string.Join(" ", Enumerable.Range(1, Config.GeneratedAffirmationWordCount).Select(i => sets[i][Random.Range(0, sets[i].Count)]));

    public static bool Contains(string word) => statements.Contains(word);

    public static void Load()
    {
        LoadTextLines("affirmations", statements);
        LoadTextLines("steps", steps);

        sets = Enumerable.Range(1, 5).ToDictionary(i => i, i => LoadTextLines($"affirmation_set_{i}"));
    }

    private static void LoadTextLines(string path, List<string> targetList)
    {
        targetList.Clear();
        TextAsset asset = Resources.Load<TextAsset>(path);
        if (asset == null) return;

        foreach (string line in asset.text.Split('\n'))
        {
            var trimmed = line.Trim();
            if (!string.IsNullOrEmpty(trimmed))
                targetList.Add(trimmed);
        }
    }

    private static List<string> LoadTextLines(string path)
    {
        var list = new List<string>();
        TextAsset asset = Resources.Load<TextAsset>(path);
        if (asset == null) return list;

        foreach (string line in asset.text.Split('\n'))
        {
            var trimmed = line.Trim();
            if (!string.IsNullOrEmpty(trimmed))
                list.Add(trimmed);
        }

        return list;
    }
}
