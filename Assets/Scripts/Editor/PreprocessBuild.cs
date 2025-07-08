using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PreprocessBuild : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    const string bundleId = "com.HeathGifford.AlwaysPresent";
    const string version = "0.0.1";
    const int todaysBuildCount = 1; // Set to 1 and increment for each build submitted, per day.

    // App store build number format. YYYYMMDD[#] -- [#] todaysBuildCount.
    public static int GetBuildNumber()
    {
        var utcNow = DateTime.UtcNow;
        string year = utcNow.Year.ToString();
        string month = utcNow.Month.ToString("00");
        string day = utcNow.Day.ToString("00");

        return int.Parse($"{year}{month}{day}{todaysBuildCount}");
    }

    static void UpdatePlayerSettings()
    {
        PlayerSettings.bundleVersion = version;

        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, bundleId);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, bundleId);
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        var buildNumber = GetBuildNumber();
        PlayerSettings.Android.bundleVersionCode = buildNumber;
        PlayerSettings.iOS.buildNumber = buildNumber.ToString();

        UpdatePlayerSettings();
    }
}