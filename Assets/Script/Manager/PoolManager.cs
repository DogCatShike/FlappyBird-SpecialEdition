using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    Transform player;

    [SerializeField] GameObject[] props;
    Dictionary<int, GameObject> propPool;

    [SerializeField] GameObject pillar;
    Dictionary<int, GameObject> pillarPool;

    [SerializeField] GameObject[] bg;
    Dictionary<int, GameObject> bgPool;

    [SerializeField] Transform pool;

    float spawnTimer;
    float spawnTime; // 生成间隔时间

    float pillarXPos; // 柱子x轴
    Transform mainCamera;
    float cameraWidth;

    float bgXPos; // 背景x轴

    void Awake()
    {
        propPool = new Dictionary<int, GameObject>();
        pillarPool = new Dictionary<int, GameObject>();
        bgPool = new Dictionary<int, GameObject>();

        spawnTimer = 0;
        spawnTime = 0;

        pillarXPos = 0;
        mainCamera = Camera.main.transform;
        cameraWidth = 9.6f;

        bgXPos = -20.48f;
    }

    void Start()
    {
        player = ContextManager.player;

        SpawnPropPool();
        SpawnPillarPool();
        SpawnBgPool();

        PickBg();

        while (pillarXPos < mainCamera.position.x + cameraWidth)
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
            spawnTime = Random.Range(3f, 10f);
            PickProp();
        }

        if (pillarXPos < mainCamera.position.x + cameraWidth)
        {
            PickPillar();
        }

        if (bgXPos < mainCamera.position.x)
        {
            PickBg();
        }
    }

    #region Prop
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

        var pos = player.position;
        pos.x += 10;
        pos.y = Random.Range(-4, 4);
        prop.transform.position = pos;

        prop.SetActive(true);
    }
    #endregion

    #region Pillar
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
        pillarXPos += Random.Range(7f, 12f);
        float pillarYPos = Random.Range(-1.5f, 1.5f);

        GameObject pillarGo = null;
        for (int i = 0; i < pillarPool.Count; i++)
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
        pillarGo.transform.position = new Vector2(pillarXPos, pillarYPos);
        pillarGo.SetActive(true);
    }
    #endregion

    #region Bg
    void SpawnBgPool()
    {
        int count = bg.Length;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(bg[i], pool);
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
                bgXPos += 20.48f;
                go.transform.position = new Vector2(bgXPos, 0);
                go.SetActive(true);
                break;
            }
        }
    }
    #endregion
}