using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private GameObject Player;

    private float Max_Height = 0;
    public Text Txt_Score;

    private int Score;

    private Vector3 Top_Left;
    private Vector3 Camera_Pos;

    private bool Game_Over = false;

    void Awake()
    {
        Player = GameObject.Find("Player");

        // Initialize boundary 
        Camera_Pos = Camera.main.transform.position;
        Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }

    void FixedUpdate()
    {
        if (!Game_Over)
        {
            // Calculate max height
            if (Player.transform.position.y > Max_Height)
            {
                Max_Height = Player.transform.position.y;
            }

            // Check player fall
            if (Player.transform.position.y - Camera.main.transform.position.y < Get_DestroyDistance())
            {
                Game_Over = true;
            }
        }
    }

    void OnGUI()
    {
        // Set score
        Score = (int)(Max_Height * 50);
        Txt_Score.text = Score.ToString();
    }

    public float Get_DestroyDistance()
    {
        return Camera_Pos.y + Top_Left.y;
    }

   
}
