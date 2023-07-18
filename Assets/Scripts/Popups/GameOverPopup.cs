using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    public void Start(){
        scoreText.text = ScoresController.Instance.Scores.ToString();
        bestScoreText.text = PlayerController.Instance.Stats.HighestScore.ToString();
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }
}
