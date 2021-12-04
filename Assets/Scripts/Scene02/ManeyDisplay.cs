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
        if (Data.money < 10000){
        moneytext.text = Data.money.ToString("0");
        }

        if (Data.money >= 10000){
        moneytext.text = string.Format("{0:0}万{1:0}円", Data.money/10000, Data.money - (Data.money/10000)*10000);
        }

        if (Data.money >= 100000000){
        moneytext.text = string.Format("{0:0}億{1:0}万{2:0}円", Data.money/100000000, (Data.money - (Data.money/100000000)*100000000)/10000, Data.money - (Data.money/10000)*10000);
        }

        if (Data.money >= 1000000000000){
        moneytext.text = string.Format("{0:0}兆{1:0}億{2:0}万{3:0}円", 
        Data.money/1000000000000, (Data.money - (Data.money/1000000000000)*1000000000000)/100000000 ,(Data.money - (Data.money/100000000)*100000000)/10000, Data.money - (Data.money/10000)*10000);
        }

        if (Data.money >= 10000000000000000){
        moneytext.text = string.Format("{0:0}京{1:0}兆{2:0}億{3:0}万円", 
        Data.money/10000000000000000, (Data.money - (Data.money/10000000000000000)*10000000000000000)/1000000000000 ,(Data.money - (Data.money/1000000000000)*1000000000000)/100000000, (Data.money - (Data.money/100000000)*100000000)/10000);
        }
        
        /*if (Data.money >= 100000000000000000000){
        moneytext.text = string.Format("{0:0}亥{1:0}京{2:0}兆{3:0}億円", 
        Data.money/10000/10000/10000/10000/10000, (Data.money - (Data.money/10000/10000/10000/10000/10000)*10000*10000*10000*10000*10000)/10000/10000/10000/10000 ,
        (Data.money - (Data.money/10000/10000/10000/10000)*10000*10000*10000*10000)/10000/10000/10000, (Data.money - (Data.money/10000/10000/10000)*10000*10000*10000)/10000/10000);
        }*/

    }
}
