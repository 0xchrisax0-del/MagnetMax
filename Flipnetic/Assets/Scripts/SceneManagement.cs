using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    float waitTime = 2f;
    public Animator anim;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnPlayClick()
    {
        StartCoroutine(loadScene("GameScene"));
    }

    public void onGameEnd()
    {
        //StartCoroutine(loadScene("GameOver"));
        SceneManager.LoadSceneAsync("GameOver");
    }

    IEnumerator loadScene(string sceneName)
    {
        anim.SetBool("isTurningOut", true);
        anim.SetBool("isTurningIn", false);

        yield return new WaitForSecondsRealtime(waitTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            yield return null;
        }

        anim.SetBool("isTurningIn", true);
    }

}
