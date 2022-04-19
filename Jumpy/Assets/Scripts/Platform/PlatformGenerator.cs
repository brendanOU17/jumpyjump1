using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject NormalPlatform;
    public GameObject BoosterPlatform;
    public GameObject DyingPlatform;
    public GameObject Platform_Brown;

    public GameObject Spring;
    public GameObject Rocket;
    //public GameObject Propeller;

    private GameObject Platform;
    private GameObject Random_Object;

    public float Current_Y = 0;
    float Offset;
    Vector3 Top_Left;

    void Start()
    {
        // Initialize boundary
        Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,0));
        Offset = 1.2f;

        // Initialize platforms
        GeneratePlatform(1);
    }
    public void GeneratePlatform(int Num)
    {
        for (int i = 0; i < Num; i++)
        {
            // Calculate platform x, y
            float Dist_X = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
            float Dist_Y = Random.Range(1f, 3f);

            
            int Rand_BrownPlatform = Random.Range(1, 20);

            if (Rand_BrownPlatform == 1)
            {
                float Brown_DistX = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                float Brown_DistY = Random.Range(Current_Y + 1, Current_Y + Dist_Y - 1);
                Vector3 BrownPlatform_Pos = new Vector3(Brown_DistX, Brown_DistY, 0);

                Instantiate(Platform_Brown, BrownPlatform_Pos, Quaternion.identity);
            }

            // Create other platform
            Current_Y += Dist_Y;
            Vector3 Platform_Pos = new Vector3(Dist_X, Current_Y, 0);
            int Rand_Platform = Random.Range(1, 10);

            if (Rand_Platform == 1) 
                Platform = Instantiate(BoosterPlatform, Platform_Pos, Quaternion.identity);
            else if (Rand_Platform == 2) 
                Platform = Instantiate(DyingPlatform, Platform_Pos, Quaternion.identity);
            else 
                Platform = Instantiate(NormalPlatform, Platform_Pos, Quaternion.identity);

            if (Rand_Platform != 2)
            {
                
                int Rand_Object = Random.Range(1, 40);

                if (Rand_Object == 4) // Create spring
                {
                    Vector3 Spring_Pos = new Vector3(Platform_Pos.x, Platform_Pos.y, 0);
                    Random_Object = Instantiate(Spring, Spring_Pos, Quaternion.identity);

                    
                    Random_Object.transform.parent = Platform.transform;
                }
                else if (Rand_Object == 7) 
                {
                    Vector3 Trampoline_Pos = new Vector3(Platform_Pos.x + 0.13f, Platform_Pos.y + 0.25f, 0);
                    Random_Object = Instantiate(Rocket, Trampoline_Pos, Quaternion.identity);

                    
                    Random_Object.transform.parent = Platform.transform;
                }
                /*else if (Rand_Object == 15) // Create propeller
                {
                    Vector3 Propeller_Pos = new Vector3(Platform_Pos.x + 0.13f, Platform_Pos.y + 0.15f, 0);
                    Random_Object = Instantiate(Propeller, Propeller_Pos, Quaternion.identity);

                    
                    Random_Object.transform.parent = Platform.transform;
                }*/
            }
        }
    }
}
