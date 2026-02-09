using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float waitTime = 2f;

    public SwipeControls swipeControls;
    public ObstacleSpawner obstacleSpawner;
    public SceneManagement sceneManager;
    public ScoreManager scoreManager;

    GameObject transitionCanvas;
    public static bool gameOver;

    void Start()
    {
        gameOver = false;
        swipeControls.enabled = true;
        obstacleSpawner.enabled = true;

        transitionCanvas = GameObject.Find("TransitionCanvas");

        // Checks if transitionCanvas isn't null, then returns a Debug.Log()
        if (transitionCanvas != null)
        {
            sceneManager = transitionCanvas.GetComponent<SceneManagement>();
            Debug.Log("Scene manager found!");
        }
    }

    public void deathSequence()
    {
        gameOver = true;
        scoreManager.gameOver = true;
        swipeControls.enabled = false;
        obstacleSpawner.enabled =false;

        scoreManager.OnPlayerDeath();
        StartCoroutine(GameOverDelay());

        Debug.Log("Hit detected!");
    }

    // IEnumerator that references sceneManager to switch scenes after Game Over.
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        sceneManager.onGameEnd();
    }


}
