using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo
{
    public int mapId {get;}
    public DifficultySO difficulty {get;}
    public int enemyAmount {get;}
    public TankSO enemyType {get;}
    public TankSO playerType {get;}
    public MapInfo mapInfo {get;}
    public GameInfo(int mapId, DifficultySO difficulty, int enemyAmount, TankSO enemyType, TankSO playerType, MapInfo mapInfo)
    {
        this.mapId = mapId;
        this.difficulty = difficulty;
        this.enemyAmount = enemyAmount;
        this.enemyType = enemyType;
        this.playerType = playerType;
        this.mapInfo = mapInfo;
    }
}
[System.Serializable]
public class MapInfo
{
    public Vector3[] obstacles;
    public Vector3[] spawnPoints;
    public MapInfo(Vector3[] obstacles, Vector3[] spawnPoints)
    {
        this.obstacles = obstacles;
        this.spawnPoints = spawnPoints;
    }
}