using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPlatform : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
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
        Platform = (GameObject)Instantiate(platformPrefab, new Vector2 (Random.Range(-3f,3f), player.transform.position.y + (14 + Random.Range(.5f,2f))),Quaternion.identity);
        Destroy(platformPrefab);
    }
}
