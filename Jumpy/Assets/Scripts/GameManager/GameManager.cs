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



    public Text TxtGameOverScore;
    public Text TxtGameOverHighsocre;

    void Awake()
    {
        Player = GameObject.Find("Doodler");

        // Initialize boundary 
        CameraPos = Camera.main.transform.position;
        TopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }

      

    void OnGUI()
    {
        // Set score
        Score = (int)(MaxHeight * 50);
        TxtScore.text = Score.ToString();
    }

   

    public float Get_DestroyDistance()
    {
        return CameraPos.y + TopLeft.y;
    }

    void Set_GameOver()
    {
        
       
    }
}
