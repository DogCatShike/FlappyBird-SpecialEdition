using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!GameManager.isGameScene)
        {
            return;
        }

        KeyCheck();
    }

    void KeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameManager.instance.OnPlayerFly();
        }
    }
}
