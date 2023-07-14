using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag(PLAYER_TAG)){
            if(!PlayerController.Instance.IsPaused){
                ScoresController.Instance.Scores++;
                StartCoroutine(FallDown());
            }
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);

//TODO Rework
        if(name == "Start Platform")
            return;
            
        MapController.Instance.GenerateNewTile();
    }

    private IEnumerator FallDown(){
        yield return new WaitForSeconds(1f);
        float fallDownSpeed = MapController.Instance.Config.FallDownSpeed;
        while(gameObject.activeInHierarchy){
            transform.Translate(Vector3.down * fallDownSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
