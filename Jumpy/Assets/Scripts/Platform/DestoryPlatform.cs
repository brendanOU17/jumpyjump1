using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryPlatform : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
           SceneManager.LoadScene("Gameover");
        }


       
    } 
    
    IEnumerator Gameover()
        {
            yield return new WaitForSeconds(3f);
            
        }
}
