using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; private set; }

    public bool Direction;

    [SerializeField] private Transform mapTransform;

    private bool isPaused;

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

        isPaused = false;
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            MoveMap();
        }
    }

    private void MoveMap()
    {
        if (Direction)
        {
            mapTransform.Translate(new Vector3(Time.deltaTime, 0, 0));
        }
        else
        {
            mapTransform.Translate(new Vector3(0, 0, -Time.deltaTime));
        }
    }
}
