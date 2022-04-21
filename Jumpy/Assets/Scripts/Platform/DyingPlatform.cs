using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingPlatform : MonoBehaviour
{
    public GameObject dyingPlatform1;
    public GameObject dyingPlatform2;
    public float JumpForce = 10f;
    public void Deactive()
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<PlatformEffector2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Deactive();
                dyingPlatform1.SetActive(false);
                dyingPlatform2.SetActive(true);
                Vector2 velocity = rb.velocity;
                velocity.y = JumpForce;
                rb.velocity = velocity;
                SoundManager.Playsound("DyingPlatformSound");
                StartCoroutine(DestoryPlatform());
            }
        }

        IEnumerator DestoryPlatform()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
