using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject pooledObject;
    [SerializeField] private int pooledAmount = 5;
    [SerializeField] private bool willGrow = true;
    private List<GameObject> pooledObjects;
    void Awake()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject) Instantiate(pooledObject);
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            pooledObjects.Add(obj);
        }
        return;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject) Instantiate(pooledObject);
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
