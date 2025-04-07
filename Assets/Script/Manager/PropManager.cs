using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public static PropManager instance;

    public static bool isUseCat;
    float catTimer;

    public static bool isUseGun;
    float gunTimes;

    public static bool isUseSlow;
    float slowTimer;

    public static bool isUseWallhack;
    float wallhackTimer;

    float propTime;
    float gunMaxTimes;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isUseCat = false;
        isUseGun = false;
        isUseSlow = false;
        isUseWallhack = false;

        catTimer = 0;
        gunTimes = 3;
        wallhackTimer = 0;

        propTime = 3;
        gunMaxTimes = 3;
    }

    void Update()
    {
        if (isUseCat)
        {
            catTimer += Time.deltaTime;
            if (catTimer >= propTime)
            {
                isUseCat = false;
            }
        }

        if (isUseGun)
        {
            if (gunTimes <= 0)
            {
                isUseGun = false;
            }
        }

        if (isUseWallhack)
        {
            wallhackTimer += Time.deltaTime;
            if (wallhackTimer >= propTime)
            {
                isUseWallhack = false;
            }
        }
    }

    public void UseCat()
    {
        catTimer = 0;
        isUseCat = true;
    }

    public void UseGun()
    {
        gunTimes = gunMaxTimes;
        isUseGun = true;
    }

    public void UseSlow()
    {
        isUseSlow = true;
    }

    public void UseWallhack()
    {
        wallhackTimer = 0;
        isUseWallhack = true;
    }
}