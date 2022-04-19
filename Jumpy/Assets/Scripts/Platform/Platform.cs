using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float JumpForce = 10f;
    private float Destroy_Distance;
    private bool Create_NewPlatform = false;

    private GameObject GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");

        // Set distance to destroy the platforms out of screen
        Destroy_Distance = GameManager.GetComponent<GameManager>().Get_DestroyDistance();
    }

    void FixedUpdate()
    {
        if (transform.position.y - Camera.main.transform.position.y < Destroy_Distance)
        {
            if (name != "FakePlatform(Clone)" && name != "Spring(Clone)" && name != "Rocket(Clone)" && !Create_NewPlatform)
            {
                GameManager.GetComponent<PlatformGenerator>().GeneratePlatform(1);
                Create_NewPlatform = true;
            }

            GetComponent<EdgeCollider2D>().enabled = false;
            GetComponent<PlatformEffector2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            if (transform.childCount > 0)
            {
                if (transform.GetChild(0).GetComponent<Platform>()) 
                {
                    transform.GetChild(0).GetComponent<EdgeCollider2D>().enabled = false;
                    transform.GetChild(0).GetComponent<PlatformEffector2D>().enabled = false;
                    transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }

           
                    
            }
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = JumpForce; 
                rb.velocity = velocity;

                PlatformType();
            }
        }
    }


    void PlatformType()
    {
        if (GetComponent<DyingPlatform>())
            GetComponent<DyingPlatform>().Deactive();
    }
}
