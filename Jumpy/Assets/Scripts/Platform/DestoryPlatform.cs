using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPlatform : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab,springPlatform;
    private GameObject Platform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 15) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springPlatform, new Vector2(Random.Range(-3f, 3f), player.transform.position.y + (4 + Random.Range(0.1f, 0.1f))), Quaternion.identity);

            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-3f, 3f), player.transform.position.y + (4 + Random.Range(0.1f, 0.1f)));
            }
        }
        else if (collision.gameObject.name.StartsWith("Bouncy"))
        {

            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-3f, 3f), player.transform.position.y + (4 + Random.Range(0.1f, 0.1f)));


            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-3f, 3f), player.transform.position.y +  (4 + Random.Range(0.1f, 0.1f))), Quaternion.identity);
            }
        }






    }   
}
