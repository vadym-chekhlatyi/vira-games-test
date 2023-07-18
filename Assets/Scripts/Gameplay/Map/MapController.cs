using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; private set; }

    public GameConfig Config;

    private int currentBlockPosition;
    private GameObject lastMapBlock;

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
        for (int i = 0; i < Config.ObjectsToPoolCount; i++)
        {
            GameObject mapBlock = Instantiate(Config.MapBlockPrefab, transform);
            mapBlock.SetActive(false);
            mapBlockPool.Add(mapBlock);
        }
    }

    public GameObject GetPooledObject() 
    { 
        for (int i = 0; i < Config.ObjectsToPoolCount; i++) 
        { 
            if (!mapBlockPool[i].activeInHierarchy) 
            { 
                return mapBlockPool[i]; 
            } 
        } 

        return null; 
    }

    public void GenerateNewTile(){
        GameObject mapBlock = GetPooledObject();

        if(currentBlockPosition == Config.MaxBlocksFromCenter){
            SetBlockPosition(mapBlock, lastMapBlock.transform.localPosition, false);
            currentBlockPosition--;
        }
        else if(currentBlockPosition == -Config.MaxBlocksFromCenter){
            SetBlockPosition(mapBlock, lastMapBlock.transform.localPosition, true);
            currentBlockPosition++;
        }
        else{
            if(GetRandomDirection() == 0)
            {
                SetBlockPosition(mapBlock, lastMapBlock.transform.localPosition, true);
                currentBlockPosition++;
            }
            else
            {
                SetBlockPosition(mapBlock, lastMapBlock.transform.localPosition, false);
                currentBlockPosition--;
            }
        }

        TryGenerateCrystal(mapBlock);

        mapBlock.SetActive(true);

        lastMapBlock = mapBlock;
    }

    private void GenerateMap()
    {
        lastMapBlock = GetPooledObject(); 
        lastMapBlock.transform.localPosition = mapFirstBlockPosition;
        currentBlockPosition = 1;
        lastMapBlock.SetActive(true);

        for (int i = 1; i < Config.ObjectsToPoolCount; i++)
        {
            GenerateNewTile();
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

    private void TryGenerateCrystal(GameObject mapBlock){
        if(Random.Range(0, 100) < Config.CrystalSpawnChance){
            mapBlock.GetComponent<MapBlock>().Crystal.SetActive(true);
        }
    }

    private int GetRandomDirection()
    {
        return Random.Range(0, 2);
    }

    public void ChangeMapColor(){
        int randomId = Random.Range(0, Config.MapColors.Count-1);
        Color newColor = Config.MapColors[randomId];
        foreach(var mapBlock in mapBlockPool){
            MapBlock mapBlockComponent = mapBlock.GetComponent<MapBlock>();
            StartCoroutine(mapBlockComponent.FadeColor(newColor));
        }
    }

}
