using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private int ingredients;
    private bool full;
    // Start is called before the first frame update
    void Start()
    {
        full = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ingredients >= 2)
        {
            full=true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!full)
        {
            other.gameObject.SetActive(false);
            ingredients++;
        }
    }
}
