using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropEntity : MonoBehaviour
{
    public PropType type;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            gameObject.SetActive(false);
        }
    }
}