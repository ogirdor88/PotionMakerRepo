using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject IngredientPrefab;
    public int cost;
    public Text costText;
    public static bool popup;


    // Start is called before the first frame update
    void Start()
    {
        popup = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(ShopHandler.inShop == false)
        {
            if (GoldCounter.instance.currentCount >= cost)
            {
                GoldCounter.instance.DecreaseGold(cost);
                GameObject newIn = Instantiate(IngredientPrefab);
                newIn.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - .5f);
            }
            else
            {
                popup = true;
            }
        }
    }
}
