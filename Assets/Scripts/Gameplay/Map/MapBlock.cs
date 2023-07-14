using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public GameObject Diamond;
    [SerializeField] private bool isStartPlatform;

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag(PLAYER_TAG)){
            if(!PlayerController.Instance.IsPaused && GameController.Instance.isGameStarted){
                ScoresController.Instance.Scores++;
                StartCoroutine(FallDown());
            }
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);

        if(isStartPlatform)
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

    public IEnumerator FadeColor(Color endColor){
        MeshRenderer mesh = GetComponent<MeshRenderer>();

        Color startColor = mesh.material.color;
        float colorChangeTime = MapController.Instance.Config.ColorChangeTime;
        Color offset = (endColor - startColor) * Time.deltaTime / colorChangeTime;
        
        while(mesh.material.color != endColor){
            mesh.material.color += offset;
            yield return new WaitForEndOfFrame();
        }
    }
}
