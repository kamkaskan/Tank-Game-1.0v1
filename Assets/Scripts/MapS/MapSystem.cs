using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapSystem : MonoBehaviour
{
    [SerializeField] private NavMeshSurface navMesh;
    private List<GameObject> obstacleList;

    void Start()
    {
        CreateMap();
    }
    void OnDisable()
    {
        foreach(GameObject g in obstacleList)
        {
            g.SetActive(false);
        }
    }
    void CreateMap()
    {
        GameInfo game = DataHolder.instance.gameInfo;
        
        SpawnMap(game.mapInfo.obstacles);
        SpawnAI(game.difficulty, game.enemyAmount, game.enemyType, game.mapInfo.spawnPoints);

        navMesh.BuildNavMesh();
    }
    void SpawnMap(Vector3[] obstacles)
    {
        GameObject obstacle;
        obstacleList = new List<GameObject>();
        foreach(Vector3 v in obstacles)
        {
            obstacle = PoolSystem.instance.Obstacles.GetPooledObject();
            obstacle.transform.localPosition = v;
            obstacle.SetActive(true);
            obstacleList.Add(obstacle);
        }
    }
    void SpawnAI(DifficultySO diffSO, int aiAmount, TankSO type, Vector3[] spawnPoints)
    {
        ShuffleSpawnPoints(spawnPoints);

        List<AiController> aiList = new List<AiController>();

        GameObject ai;
        for (int i = 0; i < aiAmount; i++)
        {
            ai = PoolSystem.instance.Ai.GetPooledObject();
            ai.transform.position = spawnPoints[i];
            AiController aiController = ai.GetComponent<AiController>();
            aiController.Init(type, diffSO);
            aiList.Add(aiController);
            ai.SetActive(true);
        }

        GameplayController.instance.SetAiList(aiList);
    }
    void ShuffleSpawnPoints(Vector3[] spawnPoints)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 tmp = spawnPoints[i];
            int r = Random.Range(i, spawnPoints.Length);
            spawnPoints[i] = spawnPoints[r];
            spawnPoints[r] = tmp;
        }
    }
}
