using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool moveRight = true;
    private float Offset = 1.2f;

    void FixedUpdate()
    {
        
        Vector3 Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (moveRight)
        {
            if (transform.position.x < -Top_Left.x - Offset)
                transform.position += new Vector3(0.1f, 0, 0);
            else
                moveRight = false;
        }
        else // Move to left
        {
            if (transform.position.x > Top_Left.x + Offset)
                transform.position -= new Vector3(0.1f, 0, 0);
            else
                moveRight = true;
        }
    }
}
