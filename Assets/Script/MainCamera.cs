using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform player; // 跟随目标(玩家)

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (player == null)
        {
            Debug.Log("Player is null");
            return;
        }

        Vector3 pos = player.position;
        pos.y = 0;
        pos.z = -10;
        transform.position = pos;
    }
}