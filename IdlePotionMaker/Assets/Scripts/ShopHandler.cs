using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shopUI;
    [SerializeField]
    private GameObject c1, c2, c3, c4, c5;
    [SerializeField]
    private TMP_Text cauldron, horn, toe, ear, dung;
    [SerializeField]
    private Button cbutton, hbutton, tbutton, ebutton, dbutton;

    private bool csold, hsold, tsold, esold, dsold, upgrade, displayPopUp, resetPop;

    [SerializeField]
    private GameObject popUp;
    [SerializeField]
    private Image background;
    [SerializeField]
    private TMP_Text popupText;

    private Color backgroundColor, textColor;

    public static bool inShop;

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
        resetPop = false;
        displayPopUp = false;
        popUp.SetActive(false);
        backgroundColor = background.color;
        textColor = popupText.color;
    }

    // Update is called once per frame
    void Update()
    {
        background.color = backgroundColor;
        popupText.color = textColor;
        if (displayPopUp) 
        {
            BrokePopUp();
        }

        if (inShop)
        {
            shopUI.SetActive(true);
        }
        else
        {
            shopUI.SetActive(false);
        }
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

    private void ResetPopUp()
    {
        backgroundColor.a = 1;
        textColor.a = 1;
    }

    private IEnumerator PopUp()
    {
        yield return new WaitForSeconds(0.1f);
        backgroundColor.a = backgroundColor.a - 0.5f * Time.deltaTime;
        textColor.a = textColor.a - 0.5f * Time.deltaTime;
    }

    private void BrokePopUp()
    {
        popUp.SetActive(true);
        if (!resetPop)
        {
            ResetPopUp();
        }
        resetPop = true;
        StartCoroutine(PopUp());
        if (backgroundColor.a <= 0 && textColor.a <= 0)
        {
            resetPop = false;
            displayPopUp = false;
            popUp.SetActive(false);
        }
    }
}
