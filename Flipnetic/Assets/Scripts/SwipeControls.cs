using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    public Position position;

    public float minSwipeDistance = 1f;
    private float maxPosX = 1.35f;
    private float minPosX = -1.35f;

    // Update is called once per frame
    void Update()
    {
        float clampedPosX = Mathf.Clamp(transform.position.x, minPosX, maxPosX);

        transform.position = new Vector2(clampedPosX, transform.position.y);

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            detectSwipe();
        }
    }

    void detectSwipe()
    {
        Vector2 swipeDistance = endTouchPos - startTouchPos;

        if(swipeDistance.magnitude > minSwipeDistance)
        {
            if(swipeDistance.x > 0) 
            {
                Debug.Log("Right");
                moveRight();
            }
            else
            {
                Debug.Log("Left");
                moveLeft();
            }
        }

    }

    void moveLeft()
    {
        transform.position = new Vector2(transform.position.x - 1.35f, transform.position.y);
        position.turnLeft();
    }

    void moveRight()
    {
        transform.position = new Vector2(transform.position.x + 1.35f, transform.position.y);
        position.turnRight();
    }
}
