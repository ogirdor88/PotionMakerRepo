using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoldCounter : MonoBehaviour
{
    public static GoldCounter instance;

    public TMP_Text goldText;
    public int currentCount;

    private void Awake()
    {
        instance = this;
    }
    

    void Start()
    {
        goldText.text = "Gold: " + currentCount.ToString();
    }

    public void IncreaseGold(int v)
    {
        currentCount += v;
        goldText.text = "Gold: " + currentCount.ToString();
    }
   
}
