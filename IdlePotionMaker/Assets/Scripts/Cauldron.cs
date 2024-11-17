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
    public float brewTime;

    private float maxTime;

    public GameObject potion1;
    public GameObject potion2;
    public GameObject potion3;
    public GameObject potion4;
    public GameObject potion5;
    public GameObject potion6;
    public GameObject potion7;
    public GameObject potion8;    
    public GameObject potion9;
    public GameObject potion10;
    public GameObject potion11;
    public GameObject trashPotion;

    private bool spawnPotion;
    private bool brewing;

    private List<string> ings;


    private Vector3 spawnPosition;

    public bool chef;

    private bool togglep;

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
        togglep = false;
    }

    // Update is called once per frame
    void Update()
    {
        chef = UsefulPotion.speedup;
        if (ingredients == 2)
        {
            Brewing();
            spawnPotion = true;
        }

        if (chef == true)
        {
            maxTime = 5;
            if(togglep == false)
            {
                StartCoroutine(ToggleSpeed());
            }
        }
        if(chef == false)
        {
            togglep = false;
            maxTime = 10;
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

    private IEnumerator ToggleSpeed()
    {
        //Debug.Log("minus" + brewTime);
        brewTime = maxTime;
        togglep= true;
        yield return new WaitForSeconds(1f);
    }

    private void Brewing()
    {
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
    }

    private void CheckPotion()
    {
        string ingOne = ings[0];
        string ingTwo = ings[1];

        //Debug.Log(ingOne);
        //Debug.Log(ingTwo);

        // Basalisc Tooth + Basalisc Tooth = Haggeling Potion
        if(ingOne == "Basalisk_Fang(Clone)" && ingTwo == "Basalisk_Fang(Clone)")
        {
            GameObject newpo = Instantiate(potion1);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Dragon Scales + Dragon Scales = Strength Potion
        else if(ingOne == "Scales(Clone)" && ingTwo == "Scales(Clone)")
        {
            GameObject newpo = Instantiate(potion2);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Basilisk Tooth  + Dragon Scales or Dragon Scales + Basalisc Tooth = Invincibility potion
        else if ((ingOne == "Scales(Clone)" && ingTwo == "Basalisk_Fang(Clone)") || (ingOne == "Basalisk_Fang(Clone)" && ingTwo == "Scales(Clone)"))
        {
            GameObject newpo = Instantiate(potion3);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Unicorn Horn + Unicorn Horn = Invisibility Potion
        else if(ingOne == "Unicorn_Horn(Clone)" && ingTwo == "Unicorn_Horn(Clone)")
        {
            GameObject newpo = Instantiate(potion4);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Dragon Scales + Unicorn Horn or Unicorn Horn + Dragon Scales = Merging Potion
        else if((ingOne == "Scales(Clone)" && ingTwo == "Unicorn_Horn(Clone)") || (ingOne == "Unicorn_Horn(Clone)" && ingTwo == "Scales(Clone)"))
        {
            GameObject newpo = Instantiate(potion5);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Basalisc Tooth + Unicorn Horn or Unicorn Horn + Basilisk Tooth = Potion of Speed
        else if ((ingOne == "Basalisk_Fang(Clone)" && ingTwo == "Unicorn_Horn(Clone)") || (ingOne == "Unicorn_Horn(Clone)" && ingTwo == "Basalisk_Fang(Clone)"))
        {
            GameObject newpo = Instantiate(potion6);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Troll Toe + Troll Toe = Potion of Flight
        else if (ingOne == "Troll_toe(Clone)" && ingTwo == "Troll_toe(Clone)")
        {
            GameObject newpo = Instantiate(potion7);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Troll Toe + Unicorn Horn or Unicorn Horn + Troll Toe = Potion of Night Vision
        else if ((ingOne == "Troll_toe(Clone)" && ingTwo == "Unicorn_Horn(Clone)") || (ingOne == "Unicorn_Horn(Clone)" && ingTwo == "Troll_toe(Clone)"))
        {
            GameObject newpo = Instantiate(potion8);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Troll Toe + Dragon Dung or Dragon Dung + Troll Toe = Potion Of Telepathy
        else if ((ingOne == "Troll_toe(Clone)" && ingTwo == "Dragon_dung(Clone)") || (ingOne == "Dragon_dung(Clone)" && ingTwo == "Troll_toe(Clone)"))
        {
            GameObject newpo = Instantiate(potion9);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Orc Ears + Dragon Dung Or Dragon Dung + Orc Ears = Potion of Persuasion
        else if ((ingOne == "Orc_ears(Clone)" && ingTwo == "Dragon_dung(Clone)") || (ingOne == "Dragon_dung(Clone)" && ingTwo == "Orc_ears(Clone)"))
        {
            GameObject newpo = Instantiate(potion10);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }

        // Orc Ears + Troll Toe Or Troll Toe + Orc Ears = Potion of Levitation
        else if ((ingOne == "Orc_ears(Clone)" && ingTwo == "Troll_toe(Clone)") || (ingOne == "Troll_toe(Clone)" && ingTwo == "Orc_ears(Clone)"))
        {
            GameObject newpo = Instantiate(potion11);
            newpo.transform.position = spawnPosition;
            ings.Clear();
        }   

        // ANY COMBINATION THAT DOES NOT EXIST = FAILED POTION
        else
        {
            GameObject newpo = Instantiate(trashPotion);
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
