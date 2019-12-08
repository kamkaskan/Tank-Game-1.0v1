using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapIconGenerator
{
    private static Color baseColor = Color.white;
    private static Color obstacleColor = Color.red;

    public static Texture2D GenerateTexture(Vector3[] obstacles)
    {
        int x = GlobalVariables.MapSizeX;
        int y = GlobalVariables.MapSizeY;
        Texture2D tex = new Texture2D(x, y, TextureFormat.ARGB32, false);
       
        Color[] mapColors = new Color[x * y];
        for(int i = 0; i < mapColors.Length; i++)
        {
            mapColors[i] = baseColor;
        }

        int gridSize = GlobalVariables.ObstacleSize;
        int textureIndex = 0;
        for(int i = 0; i < obstacles.Length; i++)
        {
            Vector3 obst = ConvertMapCenter(obstacles[i], gridSize, x, y);

            textureIndex = (int) obst.z * x + (int) obst.x;
            mapColors[textureIndex] = Color.red;
        }

        tex.SetPixels(mapColors);
        tex.filterMode = FilterMode.Point;
        return tex;
    }

    private static Vector3 ConvertMapCenter(Vector3 vectorToConvert, int gridSize, int mapSizeX, int mapSizeY)
    {
        vectorToConvert /= gridSize;
        vectorToConvert.x += mapSizeX/2;
        vectorToConvert.z += mapSizeY/2;
        return vectorToConvert;
    }
}
