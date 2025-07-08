using System.Collections.Generic;

public static class ListExtensions
{
    public static string Random(this List<string> list)
    {
        if (list == null || list.Count == 0)
            return string.Empty;

        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}
