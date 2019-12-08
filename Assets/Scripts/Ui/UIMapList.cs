using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMapList : MonoBehaviour
{
    [SerializeField] private Transform contentHolder;
    [SerializeField] private GameObject mapIconPrefab;
    public int value {get; private set;}
    private UIMapTile[] mapTiles;

    void Start()
    {
        MapInfo[] maps = DataHolder.instance.GetMaps();
        mapTiles = new UIMapTile[maps.Length];
        for (int i = 0; i < maps.Length; i++)
        {
            GameObject mapIcon = Instantiate(mapIconPrefab, contentHolder);
            
            mapTiles[i] = mapIcon.GetComponent<UIMapTile>();
            mapTiles[i].Init(i, DataHolder.instance.GetMapIcon(i), this);
        }
        mapTiles[0].Select(true);
    }

    public void UpdateSelected(int id)
    {
        if (value == id) return;
        mapTiles[value].Select(false);
        value = id;
    }
}
