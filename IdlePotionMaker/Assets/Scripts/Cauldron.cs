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
    public int brewTime;

    // Start is called before the first frame update
    void Start()
    {
        full = false;
        brewtext = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(ingredients >= 2)
        {
            full=true;
            ChangeText();
            StartCoroutine(CountDown());
            if(brewTime == 0) 
            {
                brewtext.text = "Done";
            }
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
        brewTime--;
        yield return new WaitForSeconds(1);
    }

    private void ChangeText()
    {
        brewtext.text = "Brewing: " + brewTime.ToString();
    }
}
