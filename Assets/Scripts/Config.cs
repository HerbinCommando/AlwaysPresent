using UnityEngine;

public static class Config
{
    public enum AffirmationMode
    {
        Generated,
        Stated
    }

    public static bool ConstantAffirmations;
    public static float ConstantAffirmationUpdateTime;
    public static int GeneratedAffirmationWordCount;
    public static AffirmationMode Mode;
    
    public static void Load()
    {
        ConstantAffirmations = PlayerPrefs.GetInt(nameof(ConstantAffirmations), 0) == 1;
        ConstantAffirmationUpdateTime = PlayerPrefs.GetFloat(nameof(ConstantAffirmationUpdateTime));
        GeneratedAffirmationWordCount = PlayerPrefs.GetInt(nameof(GeneratedAffirmationWordCount), 5);
        Mode = (AffirmationMode)PlayerPrefs.GetInt(nameof(Mode), (int)AffirmationMode.Stated);

    }

    public static void Save()
    {
        PlayerPrefs.SetInt(nameof(ConstantAffirmations), ConstantAffirmations ? 1 : 0);
        PlayerPrefs.SetFloat(nameof(ConstantAffirmationUpdateTime), 5.0f);
        PlayerPrefs.SetInt(nameof(GeneratedAffirmationWordCount), GeneratedAffirmationWordCount);
        PlayerPrefs.SetInt(nameof(Mode), (int)Mode);

        PlayerPrefs.Save();
    }
}
