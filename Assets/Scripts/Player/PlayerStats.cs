using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const string CRYSTALS_KEY = "Crystals";
    private const string GAMES_PLAYED = "GamesPlayed";
    private const string HIGHEST_SCORE = "HighestScore";
    public int GamesPlayed = 0;
    public int Crystals = 0;
    public int HighestScore = 0;

    public void LoadStats(){
        if(PlayerPrefs.GetInt(GAMES_PLAYED, 0) > 0){
            GamesPlayed = PlayerPrefs.GetInt(GAMES_PLAYED);
            Crystals = PlayerPrefs.GetInt(CRYSTALS_KEY);
            HighestScore = PlayerPrefs.GetInt(HIGHEST_SCORE);
        }
    }
}
