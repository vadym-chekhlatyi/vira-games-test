using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float GamesPlayed = 0;
    public float Crystals = 0;

    public void LoadStats(){
        //TODO Remove magic numbers
        if(PlayerPrefs.GetInt("GamesPlayed") > 0){
            GamesPlayed = PlayerPrefs.GetInt("GamesPlayed");
            Crystals = PlayerPrefs.GetInt("Crystals");
        }
    }
}
