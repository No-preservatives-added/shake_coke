using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;


public class MoneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneyText;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = UnitDisplay.Display(Data.money);
        moneyText.text += "円"; //表示文字列に円を追加

        //moneyText.text = Data.money.ToString("0");

    }
}
