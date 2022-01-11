using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UBUNTU_Script : MonoBehaviour
{
    [Header("Variables")]
    //Variables
    public float U_Coin;
    public float U_XP;

    [Header("Multipliers")]
    public float multiplier = 1f;
    public float XP_multiplier = 0.5f;

    [Header("UI")]
    public Text Coin;
    public Text XP;
    public Text XP_Mult;
    public Text U_Mult;
    public Slider XP_Slider;
    public Text XP_Percent;


    [Header("XP Gap")]
    int XP_Gap = 100000000;

    [Header("XP")]
    public float WaitTime;

    public int firstTime = 10;


    // Start is called before the first frame update
    void Start()
    {

        

        
        
            U_Coin = PlayerPrefs.GetFloat("U_Coin");
            U_XP = PlayerPrefs.GetFloat("U_XP");
            multiplier = PlayerPrefs.GetFloat("multiplier");
            XP_multiplier = PlayerPrefs.GetFloat("XP_multiplier");
            WaitTime = PlayerPrefs.GetFloat("WaitTime");
        

        
    }

    // Update is called once per frame
    void Update()
    {
        VU(U_XP / XP_Gap, U_XP / XP_Gap * 100);

        U_Coin += multiplier * Time.deltaTime / WaitTime;
        
        if(WaitTime <= 1.5f)
        {
            WaitTime = 1.5f;
        }

        if (Input.GetButton("Tab"))
        {
            Debug.Log("pressed");
        }
    }


    void VU(float x, float y)
    {

        //Setting Variables to Text Objects
        Coin.text = U_Coin.ToString("0");
        XP.text = "Your XP: " + U_XP.ToString("0.0");
        XP_Mult.text = XP_multiplier.ToString();
        U_Mult.text = multiplier.ToString("0");
        XP_Slider.value = x;
        XP_Percent.text = y.ToString("0") + "%";
    }

    public void Click()
    {
        U_Coin += multiplier;

        U_XP += XP_multiplier;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("U_Coin", U_Coin);
        PlayerPrefs.SetFloat("U_XP", U_XP);
        PlayerPrefs.SetFloat("multiplier", multiplier);
        PlayerPrefs.SetFloat("XP_multiplier", XP_multiplier);
        PlayerPrefs.SetFloat("WaitTime", WaitTime);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetFloat("U_Coin", 0);
        PlayerPrefs.SetFloat("U_XP", 0);
        PlayerPrefs.SetFloat("multiplier", 1f);
        PlayerPrefs.SetFloat("XP_multiplier", 0.5f);
        PlayerPrefs.SetFloat("WaitTime", 10);
        Invoke("Quit", 1);
    }

    public void QuitGame()
    {
        SaveGame();

        Invoke("Quit", 2);
    }

    private void Quit()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }
}
