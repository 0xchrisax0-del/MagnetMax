using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject shieldPowerUp; // Placed for testing purposes...
    public Transform spawnPos;
    
    void Start()
    {
        if (!enabled)
        {
            return;
        }

        InvokeRepeating("Spawn", 2f, 1f);
        InvokeRepeating("SpawnPowerUp", 1.5f, 20f); // Testing purposes...
    }

    void Spawn()
    {
        Vector2 spawnPoint = spawnPos.transform.position;
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPoint, spawnPos.transform.rotation);
    }

    void SpawnPowerUp() // Whole method for testing purposes as well...
    {
        Vector2 spawnPoint = spawnPos.transform.position;
        Instantiate(shieldPowerUp, spawnPoint, spawnPos.transform.rotation);
    }
}
