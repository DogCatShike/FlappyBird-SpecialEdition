using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float moveSpeed;
    public float upForce;

    [SerializeField] float speedUpMaxTime;
    float speedUpTimer;

    bool isGun;
    bool isCat;
    bool isWallhack;

    [SerializeField] float gunMaxTimes;
    [SerializeField] float catMaxTime;
    [SerializeField] float wallhackMaxTime;

    float gunTimes;
    float catTimer;
    float wallhackTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        speedUpTimer = 0;

        isGun = false;
        isCat = false;
        isWallhack = false;

        gunTimes = 0;
        catTimer = 0;
        wallhackTimer = 0;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        Move();
        FlyUp();
        SpeedUp(dt);

        CheckGun();
        CheckCat(dt);
        CheckWallhack(dt);
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

    void SpeedUp(float dt)
    {
        speedUpTimer += dt;

        if (speedUpTimer >= speedUpMaxTime)
        {
            speedUpTimer = 0;
            moveSpeed += 0.2f;
        }
    }

    void UseProp(PropType type)
    {
        switch (type)
        {
            case PropType.Cat:
            {
                isCat = true;
                catTimer = 0;
                upForce = 4;
                break;
            }
            case PropType.Gun:
            {
                isGun = true;
                gunTimes = 0;
                break;
            }
            case PropType.Slow:
            {
                if (moveSpeed > 5)
                {
                    moveSpeed -= 0.5f;
                }
                break;
            }
            case PropType.Wallhack:
            {
                isWallhack = true;
                wallhackTimer = 0;
                break;
            }
            default:
                break;
        }
    }

    void CheckGun()
    {
        if (!isGun) { return; }

        if (gunTimes >= gunMaxTimes)
        {
            isGun = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
            gunTimes += 1;
        }
    }

    void CheckCat(float dt)
    {
        if (!isCat) { return; }

        catTimer += dt;
        if (catTimer >= catMaxTime)
        {
            isCat = false;
            upForce = 6;
        }
    }

    void CheckWallhack(float dt)
    {
        if (!isWallhack) { return; }

        wallhackTimer += dt;
        PillarPool.instance.ShowSuperPoint();
        
        if (wallhackTimer >= wallhackMaxTime)
        {
            isWallhack = false;
        }
    }

    void Shoot()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            GameManager.instance.GameOver();
            Debug.Log("Pillar");
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

        if (other.CompareTag("SuperScorePoint"))
        {
            if (isWallhack)
            {
                GameManager.instance.AddScore(2);
            }
            else
            {
                GameManager.instance.GameOver();
                Debug.Log("SuperScorePoint");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameManager.instance.GameOver();
            Debug.Log("MainCamera");
        }
    }
}
