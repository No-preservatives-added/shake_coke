using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManeyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneytext;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //moneytext.text = Data.money.ToString("0");
        string units="";
        int unit = (Data.moneydummy_digit)/3;
        switch(unit){
            case 1:
                units="M";
                break;
            case 2:
                units="B";
                break;
            case 3:
                units="T";
                break;
            default:
                units ="";
                break;
        }

        double moneyinformation = Data.moneydummy_information * Mathf.Pow(10,Data.moneydummy_digit-unit*3);
        Debug.Log(Data.moneydummy_digit);
        Debug.Log(Data.moneydummy_information);
        Debug.Log(1.0d * Mathf.Pow(0.1f,6-5));
        moneytext.text = moneyinformation.ToString("0.00")+units;
    }
}
