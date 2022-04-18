using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    public float JumpForce = 10f;
    public GameObject spring1;
    public GameObject spring2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {  
                spring1.SetActive(false);
                spring2.SetActive(true);
                Vector2 velocity = rb.velocity;
                velocity.y = JumpForce;
                rb.velocity = velocity;
            }
        }
    }
}