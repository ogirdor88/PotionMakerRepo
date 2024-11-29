using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCauldron : MonoBehaviour
{
    [SerializeField]
    private GameObject leftButton, rightButton, cauldrons;

    [SerializeField]
    private bool change , cyStart;


    // Start is called before the first frame update
    void Start()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        change = false;
        cyStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShopHandler.csold == true)
        {
            if(cyStart == false) 
            {
                rightButton.SetActive(true);
                cyStart = true;
            }
            if(!change)
            {
                cauldrons.transform.position = Vector3.Lerp(cauldrons.transform.position, new Vector3(7.5f, 0f, 0f), 1*Time.deltaTime);
            }
            else 
            {
                cauldrons.transform.position = Vector3.Lerp(cauldrons.transform.position, new Vector3(-7.5f, 0f, 0f), 1 * Time.deltaTime);
            }
        }
    }

    public void RightButton()
    {
        change = true;
        rightButton.SetActive(false);
        leftButton.SetActive(true);
    }

    public void LeftButton() 
    {
        change = false;
        rightButton.SetActive(true);
        leftButton.SetActive(false);
    }
}
