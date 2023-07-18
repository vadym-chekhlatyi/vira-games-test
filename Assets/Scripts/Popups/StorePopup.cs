using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePopup : MonoBehaviour
{
    public void OnBackButtonClick(){
        PopUpManager.ClosePopup(PopUpManager.Popups.StorePopup);
        PopUpManager.OpenPopup(PopUpManager.Popups.MainMenuPopup);
    }
}
