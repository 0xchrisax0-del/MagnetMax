using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{

    // Update is called once per frame.
    void Update()
    {
        // If player's x position is zero, it's rotation is in default state. 
        if(transform.position.x == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    // Method is accessed by SwipeControls script to rotate player to the left.
    public void turnLeft()
    {
        Quaternion Left = Quaternion.Euler(0, 0, -90);

        // If player x position is less than zero, rotate left.
        if (transform.position.x < 0)
        {
            transform.rotation = Left;
        }
    }

    // Method is accessed by SwipeControls script to rotate player to the right.
    public void turnRight()
    {
        Quaternion Right = Quaternion.Euler(0, 0, 90);

        // If player x position is greater than zero, rotate left.
        if (transform.position.x > 0)
        {
            transform.rotation = Right;
        }
    }
}
