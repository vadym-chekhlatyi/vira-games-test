using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PopUpManager
{
    public enum Popups{
        StorePopup,
        MainMenuPopup,
        SettingsPopup,
        GameOverPopup
    }
    public static Dictionary<Popups, string> PopUpNames = new Dictionary<Popups, string>();

    public static void Init(){
        PopUpNames.Add(Popups.StorePopup, "StorePopup");
        PopUpNames.Add(Popups.MainMenuPopup, "MainMenuPopup");
        PopUpNames.Add(Popups.SettingsPopup, "SettingsPopup");
        PopUpNames.Add(Popups.GameOverPopup, "GameOverPopup");
    }

    public static void OpenPopup(Popups popup){
        SceneManager.LoadScene(PopUpNames[popup], LoadSceneMode.Additive);
    }
    
    public static void ClosePopup(Popups popup){
        SceneManager.UnloadSceneAsync(PopUpNames[popup]);
    }
}
