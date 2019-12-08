using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighscoreSystem
{
    private static string hsKey = "hs{0}";
    public static int GetHighscore(int mapId)
    {
        return PlayerPrefs.GetInt(string.Format(hsKey,mapId),0);
    }
    public static bool SetHighscore(int mapId, int hs)
    {
        if (hs < GetHighscore(mapId)) return false;
        PlayerPrefs.SetInt(string.Format(hsKey,mapId), hs);
        return true;
    }
}
