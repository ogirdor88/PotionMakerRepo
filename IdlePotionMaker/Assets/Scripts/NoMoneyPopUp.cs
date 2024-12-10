using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoMoneyPopUp : MonoBehaviour
{
    [SerializeField]
    private GameObject popUp, HTPUI;
    [SerializeField]
    private Image background;
    [SerializeField]
    private TMP_Text popupText;

    private Color backgroundColor, textColor;

    private bool resetPop;

    // Start is called before the first frame update
    void Start()
    {
        resetPop = false;
        popUp.SetActive(false);
        backgroundColor = background.color;
        textColor = popupText.color;
        HTPUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        background.color = backgroundColor;
        popupText.color = textColor;

        if(ShopHandler.displayPopUp == true || IngredientSpawner.popup == true)
        {
            BrokePopUp();
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

    public void BrokePopUp()
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
            ShopHandler.displayPopUp = false;
            IngredientSpawner.popup = false;
            popUp.SetActive(false);
        }
    }

    public void HowToPlay()
    {
        HTPUI.SetActive(true);
    }

    public void BackButton()
    {
        HTPUI.SetActive(false);
    }
}
