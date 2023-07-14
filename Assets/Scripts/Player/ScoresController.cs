using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresController : MonoBehaviour
{
    public static ScoresController Instance;
    [SerializeField] private TextMeshProUGUI scoresText;
    private float scores = 0;

    public float Scores {
        get{ return scores; }
        set{ 
            scores = value; 
            scoresText.text = value.ToString();
        }
    }

    private void Start() {
        Instance = this;
    }
}
