using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody2D rb;
    public float xMovement;
    public float score = 0.0f;
    public float highscore = 0.0f;
    private int Health;
    private int writeScore;
    private int writeHighscore;
   // public float highscore = 0.0f;
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

      if(rb.velocity.y >0 && transform.position.y > score)
        {
            score = transform.position.y;
            writeScore = Mathf.FloorToInt(score);

            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+ writeScore);
        }

      
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
        }
           
        

    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = xMovement;
        rb.velocity = velocity;
    }

    public void PlayerDie()
    {
        Health--;
            if (Health < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
       
    }
}
