using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public GameObject self;

    [Header("Variable")]
    public Text nameTXT;
    public Text descriptionTXT;
    public Text priceTXT;

    public string ItemName;
    public string description;
    public int price;
    public int amount;

    public UBUNTU_Script Script;


    // Start is called before the first frame update
    void Start()
    {
        nameTXT.text = ItemName.ToString();
        descriptionTXT.text = description.ToString();
        priceTXT.text = price.ToString();
    }

    public void Update()
    {
        
    }

    public void BuyLS()
    {
        if (Script.U_Coin >= price)
        {
            Script.U_Coin -= price;
            Script.multiplier += 1f;
            Script.XP_multiplier += 0.5f;
        }
    }

    public void BuyMKDIR()
    {
        if (Script.U_Coin >= price)
        {
            Script.U_Coin -= price;
            Script.WaitTime -= 0.5f;
        }
    }

    public void BuyXP()
    {
        if(Script.U_Coin >= price)
        {
            Script.U_Coin -= price;
            Script.U_XP += 100f;
        }
    }


}
