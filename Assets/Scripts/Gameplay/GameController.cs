using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject mainMenuUI;
    [HideInInspector] public bool isGameStarted = false;
    private PlayerController playerController;

    private void Start() {
        Instance = this;
        playerController = FindObjectOfType<PlayerController>();
        playerController.Init();
        
        PopUpManager.Init();

        MainMenuPopup main = mainMenuUI.GetComponent<MainMenuPopup>();
        main.Init(playerController.Stats);
    }

    public void StartGameplay(){
        mainMenuUI.SetActive(false);
        ingameUI.SetActive(true);
        isGameStarted = true;
        playerController.Stats.GamesPlayed++;
    }
}
