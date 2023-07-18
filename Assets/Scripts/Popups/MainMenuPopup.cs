using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuPopup : MonoBehaviour
{
    private const string BEST_SCORE_TEXT = "Best score: ";
    private const string GAMES_PLAYED_TEXT = "Games played: ";
    private const string CRYSTALS_TEXT = " x\n";
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI GamesPlayedText;
    public TextMeshProUGUI CrystalsText;
    [SerializeField] private List<Sprite> SoundIcons; 

    public void Init(PlayerStats stats) {
        BestScoreText.text = BEST_SCORE_TEXT + stats.HighestScore.ToString();
        GamesPlayedText.text = GAMES_PLAYED_TEXT + stats.GamesPlayed.ToString();
        CrystalsText.text = CRYSTALS_TEXT + stats.Crystals.ToString();
    }

    public void OnSettingsClickHandler()
    {
        PopUpManager.OpenPopup(PopUpManager.Popups.SettingsPopup);
    }

    public void OnStoreClickHandler()
    {
        PopUpManager.OpenPopup(PopUpManager.Popups.StorePopup);
    }

    public void OnPlayClickHandler()
    {
        GameController.Instance.StartGameplay();
    }

    public void ToggleSound(Image icon){
        SoundManager.Instance.IsMuted = !SoundManager.Instance.IsMuted;
        if(SoundManager.Instance.IsMuted){
            icon.sprite = SoundIcons[(int)SoundToggle.Mute];
        }else{
            icon.sprite = SoundIcons[(int)SoundToggle.Unmute];
        }
    }

    private enum SoundToggle{
        Mute,
        Unmute
    }
}
