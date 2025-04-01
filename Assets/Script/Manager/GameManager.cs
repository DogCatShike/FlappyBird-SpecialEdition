using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isGameScene;

    BirdEntity player;

    void Awake()
    {
        instance = this;
        isGameScene = true;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdEntity>();
    }

    public void OnPlayerFly()
    {
        if (player == null)
        {
            Debug.Log("Player is null");
            return;
        }

        player.FlyUp();
    }
}
