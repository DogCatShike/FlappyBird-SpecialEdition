using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropManager : MonoBehaviour
{
    BirdEntity player;

    float propMax;
    int gunMax;

    float catTimer;
    float WallhackTimer;

    [Header("UIPrefab")]
    [SerializeField] GameObject gunUI;
    [SerializeField] GameObject catUI;
    [SerializeField] GameObject wallhackUI;

    [Header("UI")]
    [SerializeField] Text gunText;
    [SerializeField] Slider catSlider;
    [SerializeField] Slider wallhackSlider;

    void Awake()
    {
        propMax = 3;
        gunMax = 3;
        catTimer = 0;
        WallhackTimer = 0;
    }

    void Start()
    {
        player = Context.player.GetComponent<BirdEntity>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        bool isUseCat = player.isUseCat;
        bool isUseGun = player.isUseGun;
        bool isUseWallhack = player.isUseWallhack;

        if (isUseCat)
        {
            CheckCat(dt);
        }

        if (isUseGun)
        {
            CheckGun(dt);
        }
    }

    void CheckCat(float dt)
    {
        catTimer += dt;

        catUI.SetActive(true);
        catSlider.value = (propMax - catTimer) / propMax;

        if (catTimer >= propMax)
        {
            catUI.SetActive(false);
            player.UpForceReset();
            catTimer = 0;
        }
    }

    void CheckGun(float dt)
    {
        gunUI.SetActive(true);
        int gunTimes = player.gunTimes;
        gunText.text = (gunMax - gunTimes).ToString();

        if (gunTimes >= gunMax)
        {
            gunUI.SetActive(false);
            player.isUseGun = false;
            player.gunTimes = 0;
        }
    }
}