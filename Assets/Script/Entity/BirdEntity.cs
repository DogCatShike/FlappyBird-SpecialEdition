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

    public bool isDead;
    public int score;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 5f;
        upForce = 6f;

        SpeedUpTimer = 0;
        SpeedUpTime = 2;

        isDead = false;
        score = 0;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        Move();
        SetRot();

        SpeedUpTimer += dt;
        if (SpeedUpTimer >= SpeedUpTime)
        {
            SpeedUp();
            SpeedUpTimer = 0;
        }
    }

    public void Reset()
    {
        moveSpeed = 5f;
        upForce = 6f;

        SpeedUpTimer = 0;

        isDead = false;
        score = 0;
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

    void UseProp(PropType type)
    {
        switch (type)
        {
            case PropType.Cat:
                UpForceDown();
                break;
            case PropType.Gun:
                Debug.Log("Gun");
                break;
            case PropType.Slow:
                SpeedDown();
                break;
            case PropType.Wallhack:
                Debug.Log("Wallhack");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            isDead = true;
        }
        else if (other.CompareTag("ScorePoint"))
        {
            score += 1;
        }
        else if (other.CompareTag("Prop"))
        {
            var type = other.GetComponent<PropEntity>().type;
            UseProp(type);
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isDead = true;
        }
    }
}