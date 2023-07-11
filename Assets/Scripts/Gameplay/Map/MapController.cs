using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; private set; }

    [SerializeField] private GameObject mapBlockPrefab;

    [SerializeField] private int objectsToPoolCount;

    private List<GameObject> mapBlockPool;
    private bool isGenerated;

    private Vector3 mapFirstBlockPosition = new Vector3(-2f, -0.5f, 3f);

    private void Awake()
    {
        CreateInstance();
        isGenerated = false;

        CreateObjectsToPool();
        GenerateMap();
    }

    private void CreateInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void CreateObjectsToPool()
    {
        mapBlockPool = new List<GameObject>();
        for (int i = 0; i < objectsToPoolCount; i++)
        {
            GameObject mapBlock = Instantiate(mapBlockPrefab, transform);
            mapBlock.SetActive(false);
            mapBlockPool.Add(mapBlock);
        }
    }

    public GameObject GetPooledObject() 
    { 
        for (int i = 0; i < objectsToPoolCount; i++) 
        { 
            if (!mapBlockPool[i].activeInHierarchy) 
            { 
                return mapBlockPool[i]; 
            } 
        } 

        return null; 
    }

    private void GenerateMap()
    {
        GameObject previousMapBlock = GetPooledObject();
        previousMapBlock.transform.localPosition = mapFirstBlockPosition;
        previousMapBlock.SetActive(true);

        for (int i = 1; i < objectsToPoolCount; i++)
        {
            GameObject mapBlock = GetPooledObject();

            if(GetRandomDirection() == 0)
            {
                mapBlock.transform.localPosition = previousMapBlock.transform.localPosition + Vector3.forward;
            }
            else
            {
                mapBlock.transform.localPosition = previousMapBlock.transform.localPosition + Vector3.left;
            }

            mapBlock.SetActive(true);

            previousMapBlock = mapBlock;
        }

        isGenerated = true;
    }

    private int GetRandomDirection()
    {
        return Random.Range(0, 2);
    }
}
