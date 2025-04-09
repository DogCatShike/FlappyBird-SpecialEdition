using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGPool : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    Dictionary<int, GameObject> bgPool;

    float xPos;
    Transform mainCamera;

    void Awake()
    {
        bgPool = new Dictionary<int, GameObject>();
        xPos = -20.48f;
        mainCamera = Camera.main.transform;
    }

    void Start()
    {
        SpawnBgPool();
        PickBg();
    }

    void Update()
    {
        if (xPos < mainCamera.position.x)
        {
            PickBg();
        }
    }

    void SpawnBgPool()
    {
        int count = bg.Length;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(bg[i], transform);
            go.SetActive(false);
            bgPool.Add(i, go);
        }
    }

    void PickBg()
    {
        int len = bgPool.Count;
        for (int i = 0; i < len; i++)
        {
            GameObject go = bgPool[i];
            if (!go.activeSelf)
            {
                xPos += 20.48f;
                go.transform.position = new Vector2(xPos, 0);
                go.SetActive(true);
                break;
            }
        }
    }
}