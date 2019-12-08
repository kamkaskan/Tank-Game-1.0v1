using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDropSystem : MonoBehaviour
{
    public static BoostDropSystem instance;
    [SerializeField] private GameObject[] dropTypes;
    private List<Vector3> possibleDropPos;
    void Awake()
    {
        instance = this;
    }
    public void Init(Vector3[] obstacles)
    {
        PopulataPossibleDropList(obstacles);
        StartCoroutine(Droppping());
    }

    void PopulataPossibleDropList(Vector3[] obstacles)
    {
        possibleDropPos = new List<Vector3>();

        List<Vector3> impossibleDropPos =  new List<Vector3>();
        impossibleDropPos.AddRange(obstacles);
        
        int mapSizeX = GlobalVariables.MapSizeX;
        int mapSizeY = GlobalVariables.MapSizeY;
        int obstacleSize = GlobalVariables.ObstacleSize;

        Vector3 newPos;
        for (int i = -mapSizeX/2 + 1; i < mapSizeX/2; i++)
        {
            for (int j = -mapSizeY/2 + 1; j < mapSizeY/2; j++)
            {
                newPos = new Vector3(i * obstacleSize, 0, j * obstacleSize);               
                if(!impossibleDropPos.Contains(newPos)) 
                {
                    possibleDropPos.Add(newPos);
                }
                else impossibleDropPos.Remove(newPos);
            }
        }
    }
    IEnumerator Droppping()
    {
        int dropAmount = GlobalVariables.DropAmount;
        float dropRate = GlobalVariables.DropRate;

        while(dropAmount > 0)
        {
            yield return new WaitForSeconds(dropRate);
            Drop();
            dropAmount--;
        }
    }
    void Drop()
    {
        GameObject drop = Instantiate(GetRandomDrop(), GetDropPos(), this.transform.rotation, this.transform);
        drop.SetActive(true);
    }

    Vector3 GetDropPos()
    {
        int arrayPos = Random.Range(0, possibleDropPos.Count); 
        Vector3 dropPos = possibleDropPos[arrayPos];
        possibleDropPos.RemoveAt(arrayPos);
        return dropPos;
    }
    GameObject GetRandomDrop()
    {
        return dropTypes[Random.Range(0, dropTypes.Length)];
    }


}
