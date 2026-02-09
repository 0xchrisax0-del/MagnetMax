using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowGlareManager : MonoBehaviour
{
    public GameObject rightBow;
    public GameObject leftBow;

    public float onDuration;

    public bool first;

    // Start is called before the first frame update
    void Start()
    {
        // If 'first' boolean is true, start ToggleLaser1(). Else, start ToggleLaser2.
        if (first)
        {
            StartCoroutine(ToggleLaser1());
        }
        else
        {
            StartCoroutine(ToggleLaser2());
        }
    }

    // Boolean method that activates right bow when true.
    void rightBowOn(bool isOn)
    {
        if (isOn)
        {
            rightBow.SetActive(true);
            leftBow.SetActive(false);
        }
    }

    // Boolean method that activates left bow when true.
    void leftBowOn(bool isOn)
    {
        if(isOn)
        {
            rightBow.SetActive(false);
            leftBow.SetActive(true);
        }
    }

    // IEnumerator that alternates right bow and left bow in intervals.
    IEnumerator ToggleLaser1()
    {
        while(true)
        {
            rightBowOn(true);
            leftBowOn(false);
            yield return new WaitForSeconds(onDuration);

            rightBowOn(false);
            leftBowOn(true);
            yield return new WaitForSeconds(onDuration);
        }
    }

    // IEnumerator that alternates left bow and right bow in intervals.
    IEnumerator ToggleLaser2()
    {
        while (true)
        {
            leftBowOn(true);
            rightBowOn(false);
            yield return new WaitForSeconds(onDuration);

            leftBowOn(false);
            rightBowOn(true);
            yield return new WaitForSeconds(onDuration);
        }
    }

}
