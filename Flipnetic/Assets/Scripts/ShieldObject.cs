using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldObject : MonoBehaviour
{
   ShieldController shieldController;

    void Start()
    {
        shieldController = FindObjectOfType<ShieldController>();
    }

    // Checks for collision detection with triggers.
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the current game object detects object tagged "Obstacle", destroy object and deactivate game object.
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            shieldController.ShieldDisable();
        }
    }
}
