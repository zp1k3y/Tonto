using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D HitInfo) {
        //Debug.Log(HitInfo.name);
        //if(HitInfo.gameObject.CompareTag("ClownMech"))
        //{
            ClownMech clown = HitInfo.GetComponent<ClownMech>();
            if (clown != null) {
                clown.TakeDamage(damage);
            }
            
        //}
        enemyPatrol enemy = HitInfo.GetComponent<enemyPatrol>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
