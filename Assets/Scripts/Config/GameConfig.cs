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
    public GameObject MapBlockPrefab;
    public GameObject CrystalPrefab;
    public float FallDownSpeed;
    public float CrystalSpawnChance = 10f;
    public int ObjectsToPoolCount;

    public int MaxBlocksFromCenter;
    public Material MapBlockMaterial;
    public int ScoresTillColorChange;
    public float ColorChangeTime;
    [ColorUsage(true)]
    public List<Color> MapColors;

}
