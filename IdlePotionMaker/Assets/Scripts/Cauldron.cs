using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    private int ingredients;
    private bool full;

    public Text brewtext;
    private int brewTime;

    public GameObject potion;

    private bool spawnPotion;

    // Start is called before the first frame update
    void Start()
    {
        full = false;
        brewtext.text = "";
        spawnPotion = false;
        brewTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredients == 2)
        {
            Brewing();
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

    private IEnumerator CountDown()
    {
        while(brewTime > 0)
        {
            Debug.Log("minus" + brewTime);
            yield return new WaitForSeconds(1f);
            brewTime--;
        }
    }

    private void Brewing()
    {
        //if (ingredients == 2)
        //{
        ChangeText();
        StartCoroutine(CountDown());
        if(brewTime < 0 ) 
        {
            ingredients = 0;
            GameObject newpo = Instantiate(potion);
        }
        //}
    }

    private void ChangeText()
    {
        brewtext.text = "Brewing: " + brewTime.ToString();
        if(brewTime <= 0) 
        {
            brewtext.text = "Done";
        }
    }
}
