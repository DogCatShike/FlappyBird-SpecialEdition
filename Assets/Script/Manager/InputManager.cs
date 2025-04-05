using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public static bool isBirdFlying;

    void Awake()
    {
        instance = this;
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
            isBirdFlying = true;
        }
    }

    public void KeyReset()
    {
        if (isBirdFlying)
        {
            isBirdFlying = false;
        }
    }
}
