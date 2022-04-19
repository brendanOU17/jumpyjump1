using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingPlatform : MonoBehaviour
{

    public void Deactive()
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<PlatformEffector2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            Deactive();
            
        }
    }
}
