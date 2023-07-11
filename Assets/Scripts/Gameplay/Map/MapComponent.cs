using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
    void OnBecameInvisible()
    {
        GenerateNewPosition();
    }

    private void GenerateNewPosition()
    {
        throw new NotImplementedException();
    }
}
