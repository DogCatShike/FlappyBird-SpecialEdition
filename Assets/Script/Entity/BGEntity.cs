using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGEntity : MonoBehaviour
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
        if (transform.position.x < mainCamera.position.x - cameraWidth * 2)
        {
            gameObject.SetActive(false);
        }
    }
}