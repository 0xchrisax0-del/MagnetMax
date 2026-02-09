using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;
    public ShieldController shieldController;
    public Rigidbody2D rb;

    public SpriteRenderer aliveSprite;
    public SpriteRenderer deadSprite;

    bool isDead;
    private float gravityForce = -9.81f;

    public static event Action playerDied;

    void Start()
    {
        isDead = false;
        spriteIsAlive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            addGravity(gravityForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerDied?.Invoke();
            activateDeathSequence();
            spriteIsAlive(false);
        }

        if(other.gameObject.CompareTag("ShieldPowerUp"))
        {
            shieldController.ShieldEnable();
            Destroy(other.gameObject);
        }
    }

    // Death sequence is activated when called upon.
    void activateDeathSequence()
    {
        isDead = true;
        gameManager.deathSequence();
    }

    // Boolean function that switches sprites based on give condition.
    bool spriteIsAlive(bool isAlive)
    {
        // If the player sprite is alive, the 'Alive' sprite is active...
        if(isAlive)
        {
            aliveSprite.enabled = true;
            deadSprite.enabled = false;
        }
        // If the player sprite is dead, the 'Dead' sprite is active...
        else
        {
            aliveSprite.enabled = false;
            deadSprite.enabled = true;
        }

        return isAlive;
    }

    // Funtion adds gravity to player after death to make falling effect.
    void addGravity(float value)
    {
        Vector2 gravity = new Vector2(0, value * Time.unscaledDeltaTime);
        transform.Translate(gravity, Space.World);
    }
}
