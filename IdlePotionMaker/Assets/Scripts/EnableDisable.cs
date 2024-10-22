using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{
    public GameObject recipes;
    public bool isEnabled = true;
    public void Awake()
    {
        recipes.SetActive(!isEnabled);
    }
    public void ButtonClicked()
    {
        isEnabled = !isEnabled;
        recipes.SetActive(isEnabled);
    }
}
