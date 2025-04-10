using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStuff : MonoBehaviour
{
    Transform mainCamera;
    float cameraWidth;

    void Awake()
    {
        mainCamera = Camera.main.transform;
        cameraWidth = 9.6f;
    }

    void Update()
    {
        string tag = gameObject.tag;

        // 背景
        if (tag == "BG")
        {
            if (transform.position.x < mainCamera.position.x - cameraWidth * 2)
            {
                gameObject.SetActive(false);
            }
            return;
        }

        // 柱子
        if (transform.position.x < mainCamera.position.x - cameraWidth)
        {
            var pillar = gameObject.GetComponent<Pillar>();
            if (pillar.isShowSuperPoint)
            {
                pillar.HideSuperPoint();
            }

            gameObject.SetActive(false);
        }
    }
}