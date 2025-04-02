using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEntity : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] Transform wing;

    float moveSpeed; // 向右移动速度
    float upForce; // 上升力

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 5f;
        upForce = 5f;
    }

    void Update()
    {
        Move();
        SetRot();
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
    
    void SetRot()
    {
        float velo = rb.velocity.y;

        var bodyRot = Quaternion.Euler(0, 0, velo);
        transform.rotation = bodyRot;
        
        velo = Mathf.Clamp(velo, -5, 5);
        velo += 5;
        velo = Mathf.Lerp(-10, 30, velo / 10);
        
        var wingRot = Quaternion.Euler(0, 0, velo);
        wing.rotation = wingRot;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            Debug.Log("Game Over");
        }
        else if (other.CompareTag("ScorePoint"))
        {
            Debug.Log("Get Score Point");
        }
    }
}