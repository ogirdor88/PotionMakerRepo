using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionOrder : MonoBehaviour
{
    public Text Ordertext;
    string PotionName;

    private bool readyOrder , hUp, tUp, eUp, dUp, mUp, lUp;
    public bool correctOrder;

    private List<string> orders;

    private bool updateList;
    private int lastnum;

    // Start is called before the first frame update
    void Start()
    {
        readyOrder = false;
        correctOrder = false;
        orders = new List<string>();
        lastnum = 0;
        orders.Add("Potion of invincibility");
        orders.Add("Potion of strength");
        orders.Add("Potion of Haggeling");
        hUp = false;
        tUp = false;
        dUp = false;
        eUp = false;
        mUp = false;
        lUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        OrderUp();
        Debug.Log( "orders in list" + orders.Count);
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
        //check to see if any potions need to be added to the list
        UpdatePotions();

        //get a random nunmber
        int randNum = ReRoll();

        //if the random number is not the same as the last number change the potion and make ready order true;
        if (randNum != lastnum)
        {
            //store the random number
            lastnum = randNum;
            PotionName = orders[randNum];
            readyOrder = true;
        }
    }

    private void UpdatePotions()
    {
        if (ShopHandler.hsold == true)
        {
            if(!hUp) 
            {
                orders.Add("Potion of Speed");
                orders.Add("Potion of Invisibility");
                hUp = true;
            }
        }
        if (ShopHandler.tsold == true)
        {
            if (!tUp)
            {
                orders.Add("Potion of Flight");
                orders.Add("Potion of Night Vision");
                tUp= true;
            }
        }
        if (ShopHandler.esold == true)
        {
            if (!eUp)
            {
                orders.Add("Potion of Persuasion");
                eUp= true;
            }
        }
        if (ShopHandler.dsold == true)
        {
            if (!dUp)
            {
                orders.Add("Potion of Telepathy");
                dUp= true;
            }
        }

        if (ShopHandler.dsold == true && ShopHandler.hsold == true)
        {
            if (!mUp)
            {
                orders.Add("Potion of Merging");
                mUp = true;
            }
        }
        if (ShopHandler.esold == true && ShopHandler.tsold == true)
        {
            if (!lUp)
            {
                orders.Add("Potion of Levitation");
                lUp = true;
            }
        }
    }
    private int ReRoll()
    {
        int value;
         value = Random.Range(0, orders.Count);
        return value;
    }

    private void OrderUp()
    {
        //Debug.Log(PotionName);
        if (!readyOrder) 
        {
            RandomPotion();
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
