using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject startScreen, CreditScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void XButton()
    {
        startScreen.SetActive(true);
        CreditScreen.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void creditsButton()
    {
        startScreen.SetActive(false);
        CreditScreen.SetActive(true);
    }
}
