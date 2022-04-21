using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAll : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Platform"))
        {
           Destroy(gameObject);
        } 
    }
}
