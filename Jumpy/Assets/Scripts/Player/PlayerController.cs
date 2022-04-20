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
    public float topScore = 0.0f;
    public Text ScoreText;
    public Text HighscoreText;
    private int Health;
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

      if(rb.velocity.y >0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        PlayerPrefs.SetFloat("Score",PlayerPrefs.GetFloat("Score")+ topScore);
        //ScoreText.text = "Score: " + Mathf.Round(topScore).ToString();

        /*if(topScore > highscore)
        {
            highscore = topScore;
            HighscoreText.text = "Highscore: " + Mathf.Round(highscore).ToString();
        }*/

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
