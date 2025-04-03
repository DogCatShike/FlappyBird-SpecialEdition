using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    GameObject player;

    [SerializeField] GameObject[] props;
    Dictionary<int, GameObject> propPool;

    [SerializeField] Transform pool;

    float spawnTimer;
    float spawnTime; // 生成间隔时间

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");

        propPool = new Dictionary<int, GameObject>();

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
            spawnTime = Random.Range(1, 3);
            PickProp();
        }
    }

    void SpawnPropPool()
    {
        int count = props.Length;
        for (int i = 0; i < count; i++)
        {
            GameObject prop = Instantiate(props[i], pool);
            prop.SetActive(false);
            propPool.Add(i, prop);
        }
    }

    void PickProp()
    {
        int index = Random.Range(0, props.Length);
        GameObject prop = propPool[index];

        var pos = player.transform.position;
        pos.x += 10;
        pos.y = Random.Range(-4, 4);
        prop.transform.position = pos;

        prop.SetActive(true);
    }
}