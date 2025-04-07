using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropEntity : MonoBehaviour
{
    public PropType type;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UseProp();
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Pillar"))
        {
            gameObject.SetActive(false);
        }
    }

    void UseProp()
    {
        if (type == PropType.Cat)
        {
            PropManager.instance.UseCat();
        }
        else if (type == PropType.Gun)
        {
            PropManager.instance.UseGun();
        }
        else if (type == PropType.Slow)
        {
            PropManager.instance.UseSlow();
        }
        else if (type == PropType.Wallhack)
        {
            PropManager.instance.UseWallhack();
        }
    }
}