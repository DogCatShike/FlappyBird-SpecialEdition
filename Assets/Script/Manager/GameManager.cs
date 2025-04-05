using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isGameScene;

    void Awake()
    {
        instance = this;
        isGameScene = true;
    }

    void Update()
    {
        if (isGameScene)
        {
            if (Time.timeScale == 1) { return; }

            OnStartGame();
        }
        else
        {
            if (Time.timeScale == 0) { return; }

            OnPauseGame();
        }
    }

    public void OnStartGame()
    {
        Time.timeScale = 1;
    }

    public void OnPauseGame()
    {
        Time.timeScale = 0;
    }
}
