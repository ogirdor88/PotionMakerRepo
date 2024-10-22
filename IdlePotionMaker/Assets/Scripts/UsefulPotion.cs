using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulPotion : MonoBehaviour
{
    [SerializeField]
    private bool speedPotion;
    [SerializeField]
    private bool HagglingPotion;
    [SerializeField]
    private float effectTime;

    public static bool speedup;
    public static bool profit;

    private float clicks;
    private float clickTime;
    private float delay;

    private void Awake()
    {
        clicks = 0;
        clickTime = 0;
        delay = 0.5f;

        speedup = false;
        profit = false;
    }

    private void OnMouseDown()
    {
        clicks++;
        // Set the time of the first click
        if (clicks == 1) 
        {
            clickTime = Time.time;
        }

        // If clicked more, check if it was clicked within the delay window, if it was clicked within the delay time activate powerup
        if (clicks > 1  && Time.time - clickTime < delay)
        {
            clicks = 0;
            clickTime = 0;
            gameObject.GetComponent<Renderer>().enabled = false;

            if (HagglingPotion) 
            {
                Debug.Log("haggeling Potion Active");
                StartCoroutine(Scamtime());
            }
            if(speedPotion)
            {
                Debug.Log("Speed Potion Active");
                StartCoroutine(FastBrew());
            }
        }

        // If the second click happens after the amount of allowed delay then reset the clicks to 0
        if(Time.time - clickTime > delay)
        {
            clicks = 0;
            clickTime = 0;
        }
    }
    private IEnumerator FastBrew()
    {
        speedup = true;
        yield return new WaitForSeconds(effectTime);
        speedup = false;
        Debug.Log("Slowing Down");
        gameObject.SetActive(false);
    }
    private IEnumerator Scamtime()
    {
        profit = true;
        yield return new WaitForSeconds(effectTime);
        profit = false;
        Debug.Log("broke boy");
        gameObject.SetActive(false);
    }

}
