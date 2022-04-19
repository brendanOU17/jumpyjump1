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
        Destroy(collision.gameObject);
    }
}
