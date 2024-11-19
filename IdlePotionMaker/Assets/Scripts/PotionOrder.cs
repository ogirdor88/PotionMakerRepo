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
    public bool correctOrder;

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
                //StartCoroutine(DeleteDelay(other.gameObject));
                Destroy(other.gameObject);
                readyOrder = false;
                StartCoroutine(ResetDelay());
            }
            
        }
    }

    private void ChangeText()
    {
        Ordertext.text = "New Order:\n" + PotionName;
    }

    private void RandomPotion()
    {
        int randNum = ReRoll();

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
            case 3:
                if(ShopHandler.hsold == true)
                {
                    PotionName = "Potion of Invisibility";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 4:
                if (ShopHandler.hsold == true)
                {
                    PotionName = "Potion of Merging";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 5:
                if (ShopHandler.hsold == true)
                {
                    PotionName = "Potion of Speed";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 6:
                if (ShopHandler.tsold == true)
                {
                    PotionName = "Potion of Flight";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 7:
                if (ShopHandler.tsold == true && ShopHandler.hsold == true)
                {
                    PotionName = "Potion of Night Vision";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 8:
                if (ShopHandler.tsold == true && ShopHandler.dsold == true)
                {
                    PotionName = "Potion of Telepathy";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 9:
                if (ShopHandler.esold == true && ShopHandler.dsold == true)
                {
                    PotionName = "Potion of Persuasion";
                }
                else
                {
                    RandomPotion();
                }
                break;
            case 10:
                if (ShopHandler.esold == true && ShopHandler.tsold == true)
                {
                    PotionName = "Potion of Levitation";
                }
                else
                {
                    RandomPotion();
                }
                break;
        }
    }

    private int ReRoll()
    {
        int value;
         value = Random.Range(0, 12);
        return value;
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
        //Debug.Log("Beep");
        if(potionName == PotionName+"(Clone)")
        {
            correctOrder = true;
            Debug.Log("correct");
        }
    }

    private IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(2);
        correctOrder = false;
    }
    
}
