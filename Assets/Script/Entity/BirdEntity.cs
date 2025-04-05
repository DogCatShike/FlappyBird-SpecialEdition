using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEntity : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] Transform wing;

    float moveSpeed; // 向右移动速度
    float upForce; // 上升力

    float SpeedUpTimer; // 加速计时器
    float SpeedUpTime;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 5f;
        upForce = 6f;

        SpeedUpTimer = 0;
        SpeedUpTime = 2;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        Move();
        SetRot();

        bool isFlying = InputManager.isBirdFlying;
        if (isFlying)
        {
            FlyUp();
            InputManager.instance.KeyReset();
        }

        SpeedUpTimer += dt;
        if (SpeedUpTimer >= SpeedUpTime)
        {
            SpeedUp();
            SpeedUpTimer = 0;
        }
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

    void SpeedUp()
    {
        moveSpeed += 0.2f;
    }

    void SpeedDown()
    {
        moveSpeed -= 0.5f;
    }

    void UpForceDown()
    {
        upForce = 4f;
    }

    void UpForceReset()
    {
        upForce = 6f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            GameManager.instance.OnGameOver();
        }
        else if (other.CompareTag("ScorePoint"))
        {
            GameManager.instance.AddScore(1);
        }
    }
}