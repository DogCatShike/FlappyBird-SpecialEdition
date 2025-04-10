using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] GameObject[] superScorePoints;
    public bool isShowSuperPoint;

    public void ShowSuperPoint()
    {
        if (isShowSuperPoint) { return; }

        int len = superScorePoints.Length;
        var point = superScorePoints[Random.Range(0, len)];

        var renderer = point.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.5f, 0.5f, 0.5f, 1);

        for (int i = 0; i < len; i++)
        {
            var superPoint = superScorePoints[i];

            if (superPoint == point) { continue; }

            superPoint.transform.tag = "Pillar";
        }

        isShowSuperPoint = true;
    }

    public void HideSuperPoint()
    {
        if (!isShowSuperPoint) { return; }

        int len = superScorePoints.Length;

        for (int i = 0; i < len; i++)
        {
            var superPoint = superScorePoints[i];
            var renderer = superPoint.GetComponent<SpriteRenderer>();
            renderer.color = new Color(1, 1, 1, 1);
            superPoint.transform.tag = "SuperScorePoint";
        }

        isShowSuperPoint = false;
    }
}
