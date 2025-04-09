using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float moveSpeed;
    public float upForce;

    public bool canShoot;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        canShoot = false;
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

    void UseProp(PropType type)
    {
        switch (type)
        {
            case PropType.Cat:
                upForce = 4;
                break;
            case PropType.Gun:
                canShoot = true;
                break;
            case PropType.Slow:
                moveSpeed -= 0.5f;
                break;
            case PropType.Wallhack:
                Debug.Log("Wallhack");
                break;
            default:
                break;
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

        if (other.CompareTag("Prop"))
        {
            PropType type = other.GetComponent<Prop>().type;
            UseProp(type);
            other.gameObject.SetActive(false);
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
