using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private GameObject Player;
    private float MaxHeight = 0;
    public Text TxtScore;

    private int Score;

    private Vector3 TopLeft;
    private Vector3 CameraPos;

    private bool GameOver = false;

    public Text TxtGameOverScore;
    public Text TxtGameOverHighsocre;

    void Awake()
    {
        Player = GameObject.Find("Doodler");

        // Initialize boundary 
        CameraPos = Camera.main.transform.position;
        TopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }

    void FixedUpdate()
    {
        if (!GameOver)
        {
            // Calculate max height
            if (Player.transform.position.y > MaxHeight)
            {
                MaxHeight = Player.transform.position.y;
            }

            // Check player fall
            if (Player.transform.position.y - Camera.main.transform.position.y < Get_DestroyDistance())
            {
                // Play game over sound
                GetComponent<AudioSource>().Play();

                // Set game over
                Set_GameOver();
                GameOver = true;
            }
        }
    }

    void OnGUI()
    {
        // Set score
        Score = (int)(MaxHeight * 50);
        TxtScore.text = Score.ToString();
    }

    public bool Get_GameOver()
    {
        return GameOver;
    }

    public float Get_DestroyDistance()
    {
        return CameraPos.y + TopLeft.y;
    }

    void Set_GameOver()
    {
        
       
    }
}
