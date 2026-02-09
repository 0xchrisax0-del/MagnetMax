using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public GameData gameData;

    int score;
    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = gameData.currentScore;
        highScore = gameData.highScore;

        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("0");
        }
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString("0");
        }

    }

    public void OnContinueClick()
    {
        SceneManager.LoadSceneAsync("StartMenu");
    }
}
