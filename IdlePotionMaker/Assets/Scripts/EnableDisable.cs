using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{
    public GameObject recipes;
    private bool isEnabled = false;

    public void Start()
    {
        recipes.SetActive(isEnabled);
    }

    public void ButtonClicked()
    {
        isEnabled = !isEnabled;
        recipes.SetActive(isEnabled);
    }
}
