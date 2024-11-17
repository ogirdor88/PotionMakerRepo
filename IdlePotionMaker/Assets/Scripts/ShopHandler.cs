using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shopUI;
    [SerializeField]
    private GameObject c1, c2, c3, c4, c5;
    [SerializeField]
    private TMP_Text cauldron, horn, toe, ear, dung;
    [SerializeField]
    private Button cbutton, hbutton, tbutton, ebutton, dbutton;

    private bool csold, hsold, tsold, esold, dsold;

    


    private bool inShop;

    // Start is called before the first frame update
    void Start()
    {
        inShop = false;
        csold = false;
        hsold = false;
        tsold = false;
        esold = false;
        dsold = false;
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

    public void CauldronButton()
    {
        c1.SetActive(false);
        cauldron.text = "Sold";
        cauldron.transform.localPosition = Vector3.zero;
        csold = true;
        cbutton.interactable = false;
    }

    public void UnicornButton()
    {
        c2.SetActive(false);
        horn.text = "Sold";
        horn.transform.localPosition = Vector3.zero;
        hsold = true;
        hbutton.interactable = false;
    }

    public void TrollButton()
    {
        c3.SetActive(false);
        toe.text = "Sold";
        toe.transform.localPosition = Vector3.zero;
        tsold = true;
        tbutton.interactable = false;
    }

    public void OrcButton()
    {
        c4.SetActive(false);
        ear.text = "Sold";
        ear.transform.localPosition = Vector3.zero;
        esold = true;
        ebutton.interactable = false;
    }

    public void DungButton()
    {
        c5.SetActive(false);
        dung.text = "Sold";
        dung.transform.localPosition = Vector3.zero;
        dsold = true;
        dbutton.interactable = false;
    }
}
