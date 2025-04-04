using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    GameObject player;

    [SerializeField] GameObject[] props;
    Dictionary<int, GameObject> propPool;

    [SerializeField] GameObject pillar;
    Dictionary<int, GameObject> pillarPool;

    [SerializeField] Transform pool;

    float spawnTimer;
    float spawnTime; // 生成间隔时间

    float xPos; // 柱子x轴
    Transform mainCamera;
    float cameraWidth;

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");

        propPool = new Dictionary<int, GameObject>();
        pillarPool = new Dictionary<int, GameObject>();

        spawnTimer = 0;
        spawnTime = 0;

        xPos = 0;
        mainCamera = Camera.main.transform;
        cameraWidth = 9.6f;
    }

    void Start()
    {
        SpawnPropPool();
        SpawnPillarPool();

        while (xPos < mainCamera.position.x + cameraWidth)
        {
            PickPillar();
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        spawnTimer += dt;

        if (spawnTimer >= spawnTime)
        {
            spawnTimer = 0;
            spawnTime = Random.Range(3, 10);
            PickProp();
        }

        if (xPos < mainCamera.position.x + cameraWidth)
        {
            PickPillar();
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

    void SpawnPillarPool()
    {
        int count = 5;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(pillar, pool);
            go.SetActive(false);
            pillarPool.Add(i, go);
        }
    }

    void PickPillar()
    {
        xPos += Random.Range(5f, 7f);
        float yPos = Random.Range(-1.5f, 1.5f);
        
        GameObject pillarGo = null;
        for(int i = 0; i < pillarPool.Count; i++)
        {
            GameObject go = pillarPool[i];
            if (!go.activeSelf)
            {
                pillarGo = go;
                break;
            }
        }

        if (pillarGo == null)
        {
            Debug.Log("No available pillars in the pool.");
            return;
        }
        pillarGo.transform.position = new Vector2(xPos, yPos);
        pillarGo.SetActive(true);
    }
}