using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance {get; private set;}
    public GameInfo gameInfo {get; private set;}
    [SerializeField] private TankSO[] playerTanks;
    [SerializeField] private TankSO[] aiTanks;
    [SerializeField] private DifficultySO[] difficulties;
    private MapInfo[] maps;
    private Texture2D[] mapIcons;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        maps = MapLoader.LoadAll();
        mapIcons = new Texture2D[maps.Length];
    }
    public MapInfo[] GetMaps()
    {
        return maps;
    }
    public Texture2D GetMapIcon(int id)
    {
        if (mapIcons[id] == null) mapIcons[id] =  MapIconGenerator.GenerateTexture(maps[id].obstacles);
        return mapIcons[id];
    }

    public void SetGameInfo(GameInfo gameInfo)
    {
        this.gameInfo = gameInfo;
    }

    public void StartGame(int difficultyId, int playerTankId, int aiTankId, int aiAmount, int mapId)
    {
        Vector3[] obs = new Vector3[0];
        Vector3[] sp = {new Vector3(5,0,5), new Vector3(-5,0,5), new Vector3(5,0,-5), new Vector3(-5,0,-5)};
        SetGameInfo(new GameInfo(
            mapId,
            difficulties[difficultyId],
            aiAmount,
            aiTanks[aiTankId],
            playerTanks[playerTankId],
            maps[mapId]
        ));
    }
}
