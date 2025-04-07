using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context: MonoBehaviour
{
    public static Transform player;
    public static Transform mainCamera;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
}