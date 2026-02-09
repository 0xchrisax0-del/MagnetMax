using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameData", menuName = "Game/GameData")]
public class GameData : ScriptableObject
{
    public int currentScore;
    public int highScore;

    private void OnEnable()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void SubmitScore(int score)
    {
        currentScore = score;

        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
