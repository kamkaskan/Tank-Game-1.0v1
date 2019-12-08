using System;
using System.IO;
using UnityEngine;

public static class MapLoader
{
    private static string filePath = "Assets/Resources/Maps";
    private static string resourcesFilePath = "Maps";
    public static MapInfo[] LoadAll()
    {
        return LoadFromResources();
    }

    static MapInfo[] LoadFromFilePath()
    {
        DirectoryInfo info = new DirectoryInfo(filePath);
        FileInfo[] fileInfo = info.GetFiles();
        MapInfo[] maps = new MapInfo[fileInfo.Length];
        string json;
        int mapLimit = 0;
        for(int i = 0; i < fileInfo.Length; i++)
        {
            if (fileInfo[i].Extension == ".txt")
            {
                json = File.ReadAllText(fileInfo[i].FullName);
                maps[mapLimit] = MapConverter.FromJson(json);
                mapLimit++;
            }
        }
        Array.Resize(ref maps, mapLimit);
        return maps;
    }

    static MapInfo[] LoadFromResources()
    {
        UnityEngine.Object[] fileInfo = Resources.LoadAll(resourcesFilePath, typeof(TextAsset));
#if DEBUG_LOGS
        Debug.Log(fileInfo.Length);
#endif
        MapInfo[] maps = new MapInfo[fileInfo.Length];
        string json;
        for(int i = 0; i < fileInfo.Length; i++)
        {
            json = ((TextAsset) fileInfo[i]).text;
            maps[i] = MapConverter.FromJson(json);
        }
        return maps;
    }
}
