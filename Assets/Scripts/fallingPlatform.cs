using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;
    private Vector2 initialPosition;

    [SerializeField] private Rigidbody2D rb;


    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Fall());
        }
        else
        {
            StartCoroutine(SpawnPlatform());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }

    private IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(destroyDelay);
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = initialPosition;
    }
}
