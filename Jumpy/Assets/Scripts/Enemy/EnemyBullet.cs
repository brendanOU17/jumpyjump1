using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed;
    PlayerController Player;
    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

    private void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
            SoundManager.Playsound("playerDieNew");
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
}
