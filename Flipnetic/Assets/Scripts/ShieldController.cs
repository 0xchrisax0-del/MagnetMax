using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject shieldObject;
    float useTime = 5f;

    // Shield object is inactive on start.
    void Start()
    {
        shieldObject.SetActive(false);
    }

    // Accessed by PlayerManager when power up collision detected by player.
    public void ShieldEnable()
    {
        shieldObject.SetActive(true);
        StartCoroutine(PowerUpLimit());
    }

    // Accessed by ShieldPowerUp to disable shield on reference.
    public void ShieldDisable()
    {
        shieldObject.SetActive(false);
    }

    // Waits for a duration of time "useTime" then deactivates the game object.
    IEnumerator PowerUpLimit()
    {
        yield return new WaitForSeconds(useTime);
        shieldObject.SetActive(false);
    }
}