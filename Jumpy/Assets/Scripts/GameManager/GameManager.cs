using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Top_Left;
    private Vector3 Camera_Pos;

    void Awake()
    {
        Player = GameObject.Find("Player");

        // Initialize boundary 
        Camera_Pos = Camera.main.transform.position;
        Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }


    public float Get_DestroyDistance()
    {
        return Camera_Pos.y + Top_Left.y;
    }

   
}
