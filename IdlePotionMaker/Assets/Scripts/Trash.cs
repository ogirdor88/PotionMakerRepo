using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Potion")
        {
            Destroy(other.gameObject);
        }
    }
}

