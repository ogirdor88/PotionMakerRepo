using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shopUI, hornRecipes;
    [SerializeField]
    private GameObject c1, c2, c3, c4, c5;
    [SerializeField]
    private TMP_Text cauldron, horn, toe, ear, dung, toeRecipes, nitVisRecipe, teleRecipe, preRecipe, levRecipe;
    [SerializeField]
    private Button cbutton, hbutton, tbutton, ebutton, dbutton;

    private bool upgrade , recipes;

    public static bool inShop, displayPopUp, csold, hsold, tsold, esold, dsold;

    [SerializeField]
    private Text hPrice, tPrice, ePrice, dPrice;

    [SerializeField]
    private GameObject UniHorn, TroToe, OrcEar, DragDung, recipeBook;

    // Start is called before the first frame update
    void Start()
    {
        inShop = false;
        csold = false;
        hsold = false;
        tsold = false;
        esold = false;
        dsold = false;
        upgrade = false;
        displayPopUp = false;
        UniHorn.SetActive(false);
        TroToe.SetActive(false);
        OrcEar.SetActive(false);
        DragDung.SetActive(false);
        hPrice.enabled = false;
        tPrice.enabled = false;
        ePrice.enabled = false;
        dPrice.enabled = false;
        hornRecipes.SetActive(false);
        toeRecipes.enabled = false;
        nitVisRecipe.enabled = false;
        teleRecipe.enabled = false;
        preRecipe.enabled = false;
        levRecipe.enabled = false;
        recipes = false;
        recipeBook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inShop)
        {
            shopUI.SetActive(true);
        }
        else
        {
            shopUI.SetActive(false);
        }

        IngredientsCheck();
    }

    public void ShopToggle()
    {
        inShop = !inShop;
    }

    public void CauldronButton()
    {
        CheckGold(int.Parse(cauldron.text));
        if (upgrade) 
        {
            c1.SetActive(false);
            cauldron.transform.localPosition = Vector3.zero;
            csold = true;
            cbutton.interactable = false;
            GoldCounter.instance.DecreaseGold(int.Parse(cauldron.text));
            cauldron.text = "Sold";
            upgrade = false;
        }   
        else
        {
            displayPopUp = true;
        }
    }

    public void UnicornButton()
    {
        CheckGold(int.Parse(horn.text));
        if (upgrade)
        {
            c2.SetActive(false);
            horn.transform.localPosition = Vector3.zero;
            hsold = true;
            hbutton.interactable = false;
            GoldCounter.instance.DecreaseGold(int.Parse(horn.text));
            horn.text = "Sold";
            upgrade = false;
        }
        else
        {
            displayPopUp = true;
        }
    }

    public void TrollButton()
    {
        CheckGold(int.Parse(toe.text));
        if (upgrade)
        {
            c3.SetActive(false);
            toe.transform.localPosition = Vector3.zero;
            tsold = true;
            tbutton.interactable = false;
            GoldCounter.instance.DecreaseGold(int.Parse(toe.text));
            toe.text = "Sold";
            upgrade = false;
        }
        else
        {
            displayPopUp = true;
        }
    }

    public void OrcButton()
    {
        CheckGold(int.Parse(ear.text));
        if (upgrade)
        {
            c4.SetActive(false);
            ear.transform.localPosition = Vector3.zero;
            esold = true;
            ebutton.interactable = false;
            GoldCounter.instance.DecreaseGold(int.Parse(ear.text));
            ear.text = "Sold";
            upgrade= false;
        }
        else
        {
            displayPopUp = true;
        }
    }

    public void DungButton()
    {
        CheckGold(int.Parse(dung.text));
        if (upgrade)
        {
            c5.SetActive(false);
            dung.transform.localPosition = Vector3.zero;
            dsold = true;
            dbutton.interactable = false;
            GoldCounter.instance.DecreaseGold(int.Parse(dung.text));
            dung.text = "Sold";
            upgrade = false;
        }
        else
        {
            displayPopUp = true;
        }
    }

    private void CheckGold( int value)
    {
        if (GoldCounter.instance.currentCount >= value) 
        {
            upgrade = true;
        }
    }

    private void IngredientsCheck()
    {
        if(csold == true)
        {
            Debug.Log("work in progress");
        }
        if(hsold == true)
        {
            UniHorn.SetActive(true);
            hPrice.enabled = true;
            hornRecipes.SetActive(true);
        }
        if(tsold == true)
        {
            TroToe.SetActive(true);
            tPrice.enabled = true;
            toeRecipes.enabled = true;
        }
        if(esold == true)
        {
            OrcEar.SetActive(true);
            ePrice.enabled = true;
        }
        if(dsold == true)
        {
            DragDung.SetActive(true);
            dPrice.enabled = true;
        }

        if (tsold == true && hsold == true)
        {
            nitVisRecipe.enabled = true;
        }

        if (tsold == true && dsold == true)
        {
            teleRecipe.enabled = true;
        }
        if (esold == true && dsold == true)
        {
            preRecipe.enabled = true;
        }
        if (tsold == true && esold == true)
        {
            levRecipe.enabled = true;
        } 

    }


    public void RecipeButton()
    {
        recipes = !recipes;
        recipeBook.SetActive(recipes);
    }
}
