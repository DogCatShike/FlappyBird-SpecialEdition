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
    }

    void UseProp()
    {
        if (type == PropType.Cat)
        {
            Debug.Log("Cat");
        }
        else if (type == PropType.Gun)
        {
            Debug.Log("Gun");
        }
        else if (type == PropType.Slow)
        {
            Debug.Log("Slow");
        }
        else if (type == PropType.Wallhack)
        {
            Debug.Log("Wallhack");
        }
    }
}