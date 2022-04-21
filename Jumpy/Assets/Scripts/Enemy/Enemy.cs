using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    float fireRate;
    private float duration = 3f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
           Fire();   
            nextFireTime = Time.time + duration;
        }
    }

    void Fire()
    {
            Instantiate(bullet, transform.position, Quaternion.identity);
  
    }

}
