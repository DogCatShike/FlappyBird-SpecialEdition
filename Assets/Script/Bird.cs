using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float moveSpeed;
    public float upForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        FlyUp();
    }

    void Move()
    {
        Vector2 velo = rb.velocity;
        velo.x = moveSpeed;
        rb.velocity = velo;
    }

    void FlyUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isFlyUp", true);

            Vector2 velo = rb.velocity;
            velo.y = upForce;
            rb.velocity = velo;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isFlyUp", false);
        }

        if (rb.velocity.y <= 0)
        {
            anim.SetBool("isFlyUp", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            GameManager.instance.GameOver();
        }

        if (other.CompareTag("ScorePoint"))
        {
            GameManager.instance.AddScore(1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameManager.instance.GameOver();
        }
    }
}
