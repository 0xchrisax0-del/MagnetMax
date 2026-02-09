using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;

    private float scoreCounter;
    private float scoreMilestone;

    public TMP_Text scoreText;
    public bool gameOver;

    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameData.ResetScore();
        score = gameData.currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            addScore();
        }

            scoreCounter += Time.deltaTime;
    }

    void addScore()
    {
        if (scoreCounter >= 1f)
        {
            score++;
            updateScoreText();
            scoreCounter -= 0.5f;
        }

        if (score >= scoreMilestone + 100)
        {
            Time.timeScale += 0.2f;
            scoreMilestone += 100;
        }
    }

    public void OnPlayerDeath()
    {
        gameData.SubmitScore(score);
    }

    void updateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("0");
        }
    }
}
