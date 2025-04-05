using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarEntity : MonoBehaviour
{
    Transform mainCamera;
    float cameraWidth;

    void Awake()
    {
        cameraWidth = 9.6f;
    }

    void Start()
    {
        mainCamera = ContextManager.mainCamera;
    }

    void Update()
    {
        if (transform.position.x < mainCamera.position.x - cameraWidth)
        {
            gameObject.SetActive(false);
        }
    }
}