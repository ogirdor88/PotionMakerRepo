using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionOrder : MonoBehaviour
{
    public Text Ordertext;
    string PotionName;

    private bool readyOrder;
    private bool correctOrder;

    // Start is called before the first frame update
    void Start()
    {
        readyOrder = false;
        correctOrder = false;
    }

    // Update is called once per frame
    void Update()
    {
        OrderUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Potion")
        {
            string potionName = other.gameObject.name;
            CheckOrder(potionName);
            if (correctOrder)
            {
                Destroy(other.gameObject);
                readyOrder = false;
                correctOrder=false;
            }
            
        }
    }

    private void ChangeText()
    {
        Ordertext.text = "New Order:\n" + PotionName;
    }

    private void RandomPotion()
    {
        int randNum = Random.Range(0, 3);

        switch (randNum) 
        {
            case 0:
                PotionName = "Potion of invincibility";
                break;
            case 1:
                PotionName = "Potion of strength";
                break;   
            case 2:
                PotionName = "Potion of Haggeling";
                break;
        }
    }

    private void OrderUp()
    {
        //Debug.Log(PotionName);
        if (!readyOrder) 
        {
            RandomPotion();
            readyOrder = true;
        } 
        ChangeText();
    }

    private void CheckOrder(string potionName)
    {
        Debug.Log("Beep");
        if(potionName == PotionName+"(Clone)")
        {
            correctOrder = true;
        }
    }
}
