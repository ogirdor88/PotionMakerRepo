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

    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        full = false;
        brewtext.text = "";
        spawnPotion = false;
        brewTime = 10;
        spawnPosition =  new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredients == 2)
        {
            Brewing();
            spawnPotion = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!full)
        {
            if(other.tag == "Ingredient")
            {
                Destroy(other.gameObject);
                ingredients++;
            }
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
            if(spawnPotion) 
            {
                ingredients = 0;
                GameObject newpo = Instantiate(potion);
                newpo.transform.position = spawnPosition;
                brewtext.text = "";
                brewTime = 10;
                spawnPotion= false;
            }
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
