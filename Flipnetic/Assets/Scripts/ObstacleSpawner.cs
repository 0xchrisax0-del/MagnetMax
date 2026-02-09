using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject shieldPowerUp; // Placed for testing purposes...
    public Transform spawnPos;

    Vector2 spawnPoint;

    void Start()
    {
        if (!enabled) return;
        spawnPoint = spawnPos.transform.position;

        InvokeRepeating("Spawn", 2f, 1f);
    }

    void Spawn()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPoint, spawnPos.transform.rotation);

        float powerUpChance = 0.15f;

        if (Random.value < powerUpChance) SpawnPowerUp();
    }

    void SpawnPowerUp() // Whole method for testing purposes as well...
    {
        Instantiate(shieldPowerUp, spawnPoint, spawnPos.transform.rotation);
    }
}
