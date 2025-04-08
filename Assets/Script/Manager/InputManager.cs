using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    BirdEntity player;

    void Start()
    {
        player = Context.player.GetComponent<BirdEntity>();
    }

    void Update()
    {
        if (GameManager.isPause)
        {
            return;
        }

        KeyCheck();
    }

    void KeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            player.FlyUp();
        }

        if (player.isUseGun)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.Shoot();
            }
        }
    }
}
