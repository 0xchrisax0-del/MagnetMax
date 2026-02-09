using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogoSceneManager : MonoBehaviour
{
    public Animator anim;

    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        anim.SetBool("isPlaying", true);

        yield return new WaitForSeconds(waitTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync("StartMenu");

        while (!operation.isDone)
        {
            yield return null;
        }

    }
}
