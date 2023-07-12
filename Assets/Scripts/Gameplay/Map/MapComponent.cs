using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private const string PLAYER_TAG = "Player";

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag(PLAYER_TAG)){
            if(!PlayerController.Instance.IsPaused){
                StartCoroutine(FallDown());
            }
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        MapController.Instance.GenerateNewTile();
    }

    private IEnumerator FallDown(){
        while(gameObject.activeInHierarchy){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
