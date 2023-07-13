using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void LateUpdate()
    {
        if (!PlayerController.Instance.IsPaused)
        {
            Vector3 ballPosition = PlayerController.Instance.transform.position;
            Vector3 ballScreenPosition = Camera.main.WorldToScreenPoint(ballPosition);
            Vector3 centerPoint = new Vector3(Screen.width / 2, Screen.height / 2, ballScreenPosition.z);
            Vector3 screenOffset = ballScreenPosition - centerPoint;
            Vector3 worldOffset = Camera.main.ScreenToWorldPoint(screenOffset) - Camera.main.ScreenToWorldPoint(Vector3.zero);

            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + worldOffset.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
