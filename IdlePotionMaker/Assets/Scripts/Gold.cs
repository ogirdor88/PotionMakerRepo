using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int value;

    public bool sale;

    private bool checkOrder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sale = UsefulPotion.profit;
        checkOrder = this.gameObject.GetComponent<PotionOrder>().correctOrder;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Potion"))
        {
            if (sale)
            {
                if (checkOrder)
                {
                    value = 25 * 2;
                    GoldCounter.instance.IncreaseGold(value);
                }              
            }
            else 
            {
                if (checkOrder) 
                {
                    value = 25;
                    GoldCounter.instance.IncreaseGold(value);
                }
            }
        }
        
    }

}
