using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        InputHandler.Instance.SignalOnClick = OnClick;
    }

    private void OnClick()
    {
        //TODO add click logic
        Debug.Log("Click!");
        MapController.Instance.Direction = !MapController.Instance.Direction;
    }
}
