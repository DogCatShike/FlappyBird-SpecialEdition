using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 30;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            gameObject.SetActive(false);
        }
    }
}