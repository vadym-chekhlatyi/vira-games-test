using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; private set; }

    [SerializeField] private GameObject mapBlockPrefab;

    [SerializeField] private int objectsToPoolCount;

    [SerializeField] private int maxBlocksFromCenter;
    private int currentBlockPosition;

    private List<GameObject> mapBlockPool;
    private bool isGenerated;

    private Vector3 mapFirstBlockPosition = new Vector3(-2.5f, -0.5f, 3.5f);

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

    public void GenerateNewTile(){

    }

    private void GenerateMap()
    {
        GameObject previousMapBlock = GetPooledObject();
        previousMapBlock.transform.localPosition = mapFirstBlockPosition;
        currentBlockPosition = 1;
        previousMapBlock.SetActive(true);

        for (int i = 1; i < objectsToPoolCount; i++)
        {
            GameObject mapBlock = GetPooledObject();

            if(currentBlockPosition == maxBlocksFromCenter){
                SetBlockPosition(mapBlock, previousMapBlock.transform.localPosition, false);
                currentBlockPosition--;
            }
            else if(currentBlockPosition == -maxBlocksFromCenter){
                SetBlockPosition(mapBlock, previousMapBlock.transform.localPosition, true);
                currentBlockPosition++;
            }
            else{
                if(GetRandomDirection() == 0)
                {
                    SetBlockPosition(mapBlock, previousMapBlock.transform.localPosition, true);
                    currentBlockPosition++;
                }
                else
                {
                    SetBlockPosition(mapBlock, previousMapBlock.transform.localPosition, false);
                    currentBlockPosition--;
                }
            }

            mapBlock.SetActive(true);

            previousMapBlock = mapBlock;
        }

        isGenerated = true;
    }

    private void SetBlockPosition(GameObject mapBlock, Vector3 previousBlockPosition, bool isRight){
        if(isRight){
            mapBlock.transform.localPosition = previousBlockPosition + Vector3.forward;
        }
        else{
            mapBlock.transform.localPosition = previousBlockPosition + Vector3.left;
        }
    }
    
    private void SetBlockPositionToRight(GameObject mapBlock){

    }

    private int GetRandomDirection()
    {
        return Random.Range(0, 2);
    }
}
