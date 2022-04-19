using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody2D rb;
    public float xMovement;
    public float topScore;
    public float highscore;
    public Text scoreboard;
    public Text highScoreText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
       xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        if (xMovement < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }

        scoreboard.text = "Score: " + Mathf.Round(topScore).ToString();


      
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = xMovement;
        rb.velocity = velocity;
    }
}
