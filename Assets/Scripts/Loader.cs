using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Affirmations
{
    public static Dictionary<int, List<string>> sets = new();
    public static List<string> statements = new List<string>();
    public static List<string> steps = new List<string>();

    public static string NextStatement => statements.Random();
    public static string NextGenerated => string.Join(" ", Enumerable.Range(1, Config.GeneratedAffirmationWordCount).Select(i => sets[i][Random.Range(0, sets[i].Count)]));

    public static bool Contains(string word)
    {
        return statements.Contains(word);
    }

    public static void Load()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("affirmations");
        string[] fileLines = textAsset.text.Split('\n');

        for (int i = 0; i < fileLines.Length; i++)
        {
            string line = fileLines[i].Trim();

            statements.Add(line);
        }

        sets = Enumerable.Range(1, 5).Select(i => new {Key = i, Lines = Resources.Load<TextAsset>($"affirmation_set_{i}").text.Split('\n').Select(line => line.Trim()).Where(line => !string.IsNullOrEmpty(line)).ToList() ?? new List<string>()}).ToDictionary(x => x.Key, x => x.Lines);

        // Load steps.txt
        TextAsset stepsAsset = Resources.Load<TextAsset>("steps");
        if (stepsAsset != null)
        {
            steps = stepsAsset.text.Split('\n')
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .ToList();
        }

        sets = Enumerable.Range(1, 5)
            .Select(i => new
            {
                Key = i,
                Lines = Resources.Load<TextAsset>($"affirmation_set_{i}")
                    .text.Split('\n')
                    .Select(line => line.Trim())
                    .Where(line => !string.IsNullOrEmpty(line))
                    .ToList()
            })
            .ToDictionary(x => x.Key, x => x.Lines);
    }
}
