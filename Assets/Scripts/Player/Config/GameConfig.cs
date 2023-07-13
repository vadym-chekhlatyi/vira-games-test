using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("Player")]
    public float PlayerMovementSpeed;
    
    [Space]
    [Header("Map")]
    public float FallDownSpeed;
    public GameObject MapBlockPrefab;

    public int ObjectsToPoolCount;

    public int MaxBlocksFromCenter;

}
