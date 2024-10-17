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
    private float brewTime;

    private float maxTime;

    public GameObject potion1;
    public GameObject potion2;
    public GameObject potion3;

    private bool spawnPotion;
    private bool brewing;

    private List<string> ings;


    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        ings = new List<string>();
        full = false;
        brewtext.text = "";
        spawnPotion = false;
        brewTime = 10;
        spawnPosition =  new Vector3(this.transform.position.x, this.transform.position.y + 2.0f, this.transform.position.z);
        maxTime = brewTime;
        brewing = false;
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
        if (!full && !brewing)
        {
            if(other.tag == "Ingredient")
            {
                ings.Add(other.gameObject.name);
                Debug.Log("in the pot");
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                ingredients++;
            }
        }
    }

    private IEnumerator CountDown()
    {
        //Debug.Log("minus" + brewTime);
        brewTime -= 1* Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }

    private void Brewing()
    {
        //if (ingredients == 2)
        //{
        brewing = true;
        ChangeText();
        if( brewTime > 0) 
        {
            StartCoroutine(CountDown());
        }
        if(brewTime <= 0 ) 
        {
            if(spawnPotion) 
            {
                ingredients = 0;
                CheckPotion();
                brewtext.text = "";
                brewTime = maxTime;
                spawnPotion= false;
            }
            brewing= false;
        }
        //}
    }

    private void CheckPotion()
    {
        string ingOne = ings[0];
        string ingTwo = ings[1];

        //Debug.Log(ingOne);
        //Debug.Log(ingTwo);

        if(ingOne == "Basalisk_Fang(Clone)" && ingTwo == "Basalisk_Fang(Clone)")
        {
            GameObject newpo = Instantiate(potion1);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        if(ingOne == "Scales(Clone)" && ingTwo == "Scales(Clone)")
        {
            GameObject newpo = Instantiate(potion2);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        if ((ingOne == "Scales(Clone)" && ingTwo == "Basalisk_Fang(Clone)") || (ingOne == "Basalisk_Fang(Clone)" && ingTwo == "Scales(Clone)"))
        {
            GameObject newpo = Instantiate(potion3);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }


    }

    private void ChangeText()
    {
        brewtext.text = "Brewing: " + brewTime.ToString("0");
        if(brewTime <= 0) 
        {
            brewtext.text = "Done";
        }
    }
}
