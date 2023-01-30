using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; private set; }

    [SerializeField] private GameObject mapBlockPrefab;

    [SerializeField] private int objectsToPool;

    private List<GameObject> mapPool = new List<GameObject>();

    private void Awake()
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


}
