using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool isGameStarted = false;
    private void Start() {
        Instance = this;
        PopUpManager.Init();
        StartGameplay();
    }

    private void StartGameplay(){
        string mainMenuPopUpName = PopUpManager.PopUpNames[PopUpManager.Popups.MainMenuPopup];
        if(SceneManager.GetSceneByName(mainMenuPopUpName).isLoaded){
            SceneManager.UnloadSceneAsync(mainMenuPopUpName);
        }
        isGameStarted = true;
    }
}
