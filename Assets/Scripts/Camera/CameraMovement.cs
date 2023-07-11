using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!PlayerController.Instance.IsPaused)
        {
            float movementSpeed = PlayerController.Instance.Config.movementSpeed / 2.8f * Time.deltaTime;
            //movementSpeed /= PlayerController.Instance.config.movementSpeed;
            transform.Translate(new Vector3(0f, movementSpeed, 0f)); 
        }
    }
}
