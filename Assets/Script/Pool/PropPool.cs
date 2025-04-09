using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPool : MonoBehaviour
{
    [SerializeField] GameObject[] propPrefabs;
    Dictionary<int, GameObject> propPool;

    Transform mainCamera;

    float spawnTimer;
    float spawnTime;

    void Awake()
    {
        propPool = new Dictionary<int, GameObject>();
        mainCamera = Camera.main.transform;

        spawnTimer = 0;
        spawnTime = 0;
    }

    void Start()
    {
        SpawnPropPool();
    }

    void Update()
    {
        float dt = Time.deltaTime;
        spawnTimer += dt;

        if (spawnTimer >= spawnTime)
        {
            spawnTimer = 0;
            spawnTime = Random.Range(3f, 7f);
            PickProp();
        }
    }

    void SpawnPropPool()
    {
        int count = propPrefabs.Length;
        for (int i = 0; i < count; i++)
        {
            GameObject prop = Instantiate(propPrefabs[i], transform);
            prop.SetActive(false);
            propPool.Add(i, prop);
        }
    }

    void PickProp()
    {
        int index = Random.Range(0, propPrefabs.Length);
        GameObject prop = propPool[index];

        var pos = mainCamera.position;
        pos.x += 10;
        pos.y = Random.Range(-4, 4);
        pos.z = 0;
        prop.transform.position = pos;

        prop.SetActive(true);
    }
}