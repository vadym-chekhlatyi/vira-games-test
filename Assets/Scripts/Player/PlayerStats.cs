using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const string CRYSTALS_KEY = "Crystals";
    private const string GAMES_PLAYED_KEY = "GamesPlayed";
    private const string HIGHEST_SCORE_KEY = "HighestScore";

    public int GamesPlayed {
        get{
            return gamesPlayed;
        }
        set{
            gamesPlayed = value;
            PlayerPrefs.SetInt(GAMES_PLAYED_KEY, gamesPlayed);
        }
    }

    public int Crystals {
        get{
            return crystals;
        }
        set{
            crystals = value;
            PlayerPrefs.SetInt(CRYSTALS_KEY, crystals);
        }
    }

    public int HighestScore {
        get{
            return highestScore;
        }
        set{
            highestScore = value;
            PlayerPrefs.SetInt(HIGHEST_SCORE_KEY, highestScore);
        }
    }
    
    private int gamesPlayed;
    private int crystals;
    private int highestScore;

    public void Init(){
        if(PlayerPrefs.GetInt(GAMES_PLAYED_KEY, 0) > 0){
            GamesPlayed = PlayerPrefs.GetInt(GAMES_PLAYED_KEY, 0);
            Crystals = PlayerPrefs.GetInt(CRYSTALS_KEY, 0);
            HighestScore = PlayerPrefs.GetInt(HIGHEST_SCORE_KEY, 0);
        }
    }
}
