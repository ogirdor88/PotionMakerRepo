using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shopUI;

    private bool inShop;

    // Start is called before the first frame update
    void Start()
    {
        inShop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inShop)
        {
            shopUI.SetActive(true);
        }
        else
        {
            shopUI.SetActive(false);
        }
    }

    public void ShopToggle()
    {
        inShop = !inShop;
    }
}
