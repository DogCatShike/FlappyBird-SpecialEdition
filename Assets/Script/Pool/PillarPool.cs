using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPool : MonoBehaviour
{
    public static PillarPool instance;

    [SerializeField] GameObject pillarPrefab;
    Dictionary<int, GameObject> pillarPool;

    float xPos;

    Transform mainCamera;
    float cameraWidth;

    void Awake()
    {
        instance = this;

        pillarPool = new Dictionary<int, GameObject>();
        xPos = 0;

        mainCamera = Camera.main.transform;
        cameraWidth = 9.6f;
    }

    void Start()
    {
        SpawnPillarPool();

        while (xPos < mainCamera.position.x + cameraWidth)
        {
            PickPillar();
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (xPos < mainCamera.position.x + cameraWidth)
        {
            PickPillar();
        }
    }

    void SpawnPillarPool()
    {
        int count = 5;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(pillarPrefab, transform);
            go.SetActive(false);
            pillarPool.Add(i, go);
        }
    }

    void PickPillar()
    {
        xPos += Random.Range(7f, 12f);
        float yPos = Random.Range(-1.5f, 1.5f);

        GameObject pillar = null;
        for (int i = 0; i < pillarPool.Count; i++)
        {
            GameObject go = pillarPool[i];
            if (!go.activeSelf)
            {
                pillar = go;
                break;
            }
        }

        pillar.transform.position = new Vector2(xPos, yPos);

        foreach (Transform child in pillar.transform)
        {
            child.gameObject.SetActive(true);
        }
        pillar.SetActive(true);
    }

    public void ShowSuperPoint()
    {
        int len = pillarPool.Count;

        for (int i = 0; i < len; i++)
        {
            var pillar = pillarPool[i];
            if (pillar.activeSelf)
            {
                var pillarScript = pillar.GetComponent<Pillar>();
                if (!pillarScript.isShowSuperPoint)
                {
                    pillarScript.ShowSuperPoint();
                    break;
                }
            }
        }
    }
}