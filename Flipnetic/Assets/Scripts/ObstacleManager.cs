using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float destroyPosY = -7f;

    // Update is called once per frame
    void Update()
    {
        destroyObject();
    }

    // Current game object is destroyed once it reaches a certain position on y axis.
    void destroyObject()
    {
        if(transform.position.y <= destroyPosY)
        {
            Destroy(gameObject);
        }
    }
}
