using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEntity : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    float moveSpeed; // 向右移动速度
    float upForce; // 上升力

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        moveSpeed = 5f;
        upForce = 5f;
    }

    void Update()
    {
        Move();
        
        anim.SetFloat("VeloY", rb.velocity.y);
    }

    void Move()
    {
        Vector2 velo = rb.velocity;
        velo.x = moveSpeed;
        rb.velocity = velo;
    }

    public void FlyUp()
    {
        Vector2 velo = rb.velocity;
        velo.y = upForce;
        rb.velocity = velo;
    }
}