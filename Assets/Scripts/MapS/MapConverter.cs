using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
public static class MapConverter
{
    public static MapInfo FromJson(string mapJson)
    {
        return JsonUtility.FromJson<MapInfo>(mapJson);
    }

    public static string ToJson(MapInfo mapInfo)
    {
        return JsonUtility.ToJson(mapInfo);
    }
}
