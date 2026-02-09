using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed;
    private bool canMove = true;

    void OnEnable()
    {
        PlayerManager.playerDied += StopMoving;

        if(GameManager.gameOver)
        {
            canMove = false;
        }
    }

    void OnDisable()
    {
        PlayerManager.playerDied -= StopMoving;
    }

    void StopMoving()
    {
        canMove = false;
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

    }
}
