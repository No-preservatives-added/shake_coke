using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;


public class MoneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneytext;
    private int money_string_text = 0;
    
/*
    public static BigInteger kei = 10000000000000000;
    public static BigInteger gai = kei*10000;
    public static BigInteger jo = gai*10000;
    public static BigInteger jou = jo*10000;
    public static BigInteger kou = jou*10000;
    public static BigInteger kan = kou*10000;
    public static BigInteger sei = kan*10000;
    public static BigInteger sai = sei*10000;
    public static BigInteger goku = sai*10000;
    public static BigInteger gougasya = goku*10000;
    public static BigInteger asougi = gougasya*10000;
    public static BigInteger nayuta = asougi*10000;
    public static BigInteger hukashigi = nayuta*10000;
    public static BigInteger muryoutaisuu = hukashigi*10000;
*/
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        moneytext.text = Data.money.ToString("0");
        /*
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
        
        if (Data.money >= gai){
        moneytext.text = string.Format("{0:0}垓{1:0}京{2:0}兆{3:0}億円", 
        Data.money/BigInteger.Pow(10000,5), (Data.money - (Data.money/BigInteger.Pow(10000,5))*BigInteger.Pow(10000,5))/BigInteger.Pow(10000,4) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,4))*BigInteger.Pow(10000,4))/BigInteger.Pow(10000,3), (Data.money - (Data.money/BigInteger.Pow(10000,3))*BigInteger.Pow(10000,3))/BigInteger.Pow(10000,2));
        }

        if (Data.money >= jo){
        moneytext.text = string.Format("{0:0}𥝱{1:0}垓{2:0}京{3:0}兆円",
        Data.money/BigInteger.Pow(10000,6), (Data.money - (Data.money/BigInteger.Pow(10000,6))*BigInteger.Pow(10000,6))/BigInteger.Pow(10000,5) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,5))*BigInteger.Pow(10000,5))/BigInteger.Pow(10000,4), (Data.money - (Data.money/BigInteger.Pow(10000,4))*BigInteger.Pow(10000,4))/BigInteger.Pow(10000,3));
        }

        if (Data.money >= jou){
        moneytext.text = string.Format("{0:0}穣{1:0}𥝱{2:0}垓{3:0}京円",
        Data.money/BigInteger.Pow(10000,7), (Data.money - (Data.money/BigInteger.Pow(10000,7))*BigInteger.Pow(10000,7))/BigInteger.Pow(10000,6) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,6))*BigInteger.Pow(10000,6))/BigInteger.Pow(10000,5), (Data.money - (Data.money/BigInteger.Pow(10000,5))*BigInteger.Pow(10000,5))/BigInteger.Pow(10000,4));
        }

        if (Data.money >= kou){
        moneytext.text = string.Format("{0:0}溝{1:0}穣{2:0}𥝱{3:0}垓円",
        Data.money/BigInteger.Pow(10000,8), (Data.money - (Data.money/BigInteger.Pow(10000,8))*BigInteger.Pow(10000,8))/BigInteger.Pow(10000,7) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,7))*BigInteger.Pow(10000,7))/BigInteger.Pow(10000,6), (Data.money - (Data.money/BigInteger.Pow(10000,6))*BigInteger.Pow(10000,6))/BigInteger.Pow(10000,5));
        }

        if (Data.money >= kan){
        moneytext.text = string.Format("{0:0}澗{1:0}溝{2:0}穣{3:0}𥝱円",
        Data.money/BigInteger.Pow(10000,9), (Data.money - (Data.money/BigInteger.Pow(10000,9))*BigInteger.Pow(10000,9))/BigInteger.Pow(10000,8) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,8))*BigInteger.Pow(10000,8))/BigInteger.Pow(10000,7), (Data.money - (Data.money/BigInteger.Pow(10000,7))*BigInteger.Pow(10000,7))/BigInteger.Pow(10000,6));
        }

        if (Data.money >= sei){
        moneytext.text = string.Format("{0:0}正{1:0}澗{2:0}溝{3:0}穣円",
        Data.money/BigInteger.Pow(10000,10), (Data.money - (Data.money/BigInteger.Pow(10000,10))*BigInteger.Pow(10000,10))/BigInteger.Pow(10000,9) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,9))*BigInteger.Pow(10000,9))/BigInteger.Pow(10000,8), (Data.money - (Data.money/BigInteger.Pow(10000,8))*BigInteger.Pow(10000,8))/BigInteger.Pow(10000,7));
        }

        if (Data.money >= sai){
        moneytext.text = string.Format("{0:0}載{1:0}正{2:0}澗{3:0}溝円",
        Data.money/BigInteger.Pow(10000,11), (Data.money - (Data.money/BigInteger.Pow(10000,11))*BigInteger.Pow(10000,11))/BigInteger.Pow(10000,10) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,10))*BigInteger.Pow(10000,10))/BigInteger.Pow(10000,9), (Data.money - (Data.money/BigInteger.Pow(10000,9))*BigInteger.Pow(10000,9))/BigInteger.Pow(10000,8));
        }
        
        if (Data.money >= goku){
        moneytext.text = string.Format("{0:0}極{1:0}載{2:0}正{3:0}澗円",
        Data.money/BigInteger.Pow(10000,12), (Data.money - (Data.money/BigInteger.Pow(10000,12))*BigInteger.Pow(10000,12))/BigInteger.Pow(10000,11) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,11))*BigInteger.Pow(10000,11))/BigInteger.Pow(10000,10), (Data.money - (Data.money/BigInteger.Pow(10000,10))*BigInteger.Pow(10000,10))/BigInteger.Pow(10000,9));
        }

        if (Data.money >= gougasya){
        moneytext.text = string.Format("{0:0}恒河沙{1:0}極{2:0}載{3:0}正円",
        Data.money/BigInteger.Pow(10000,13), (Data.money - (Data.money/BigInteger.Pow(10000,13))*BigInteger.Pow(10000,13))/BigInteger.Pow(10000,12) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,12))*BigInteger.Pow(10000,12))/BigInteger.Pow(10000,11), (Data.money - (Data.money/BigInteger.Pow(10000,11))*BigInteger.Pow(10000,11))/BigInteger.Pow(10000,10));
        }

        if (Data.money >= asougi){
        moneytext.text = string.Format("{0:0}阿僧祇{1:0}恒河沙{2:0}極{3:0}載円",
        Data.money/BigInteger.Pow(10000,14), (Data.money - (Data.money/BigInteger.Pow(10000,14))*BigInteger.Pow(10000,14))/BigInteger.Pow(10000,13) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,13))*BigInteger.Pow(10000,13))/BigInteger.Pow(10000,12), (Data.money - (Data.money/BigInteger.Pow(10000,12))*BigInteger.Pow(10000,12))/BigInteger.Pow(10000,11));
        }

        if (Data.money >= nayuta){
        moneytext.text = string.Format("{0:0}那由他{1:0}阿僧祇{2:0}恒河沙{3:0}極円",
        Data.money/BigInteger.Pow(10000,15), (Data.money - (Data.money/BigInteger.Pow(10000,15))*BigInteger.Pow(10000,15))/BigInteger.Pow(10000,14) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,14))*BigInteger.Pow(10000,14))/BigInteger.Pow(10000,13), (Data.money - (Data.money/BigInteger.Pow(10000,13))*BigInteger.Pow(10000,13))/BigInteger.Pow(10000,12));
        }

        if (Data.money >= hukashigi){
        moneytext.text = string.Format("{0:0}不可思議{1:0}那由他{2:0}阿僧祇{3:0}恒河沙円",
        Data.money/BigInteger.Pow(10000,16), (Data.money - (Data.money/BigInteger.Pow(10000,16))*BigInteger.Pow(10000,16))/BigInteger.Pow(10000,15) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,15))*BigInteger.Pow(10000,15))/BigInteger.Pow(10000,14), (Data.money - (Data.money/BigInteger.Pow(10000,14))*BigInteger.Pow(10000,14))/BigInteger.Pow(10000,13));
        }

        if (Data.money >= muryoutaisuu){
        moneytext.text = string.Format("{0:0}無量大数{1:0}不可思議{2:0}那由他{3:0}阿僧祇円",
        Data.money/BigInteger.Pow(10000,17), (Data.money - (Data.money/BigInteger.Pow(10000,17))*BigInteger.Pow(10000,17))/BigInteger.Pow(10000,16) ,
        (Data.money - (Data.money/BigInteger.Pow(10000,16))*BigInteger.Pow(10000,16))/BigInteger.Pow(10000,15), (Data.money - (Data.money/BigInteger.Pow(10000,15))*BigInteger.Pow(10000,15))/BigInteger.Pow(10000,14));
        }

        for (int i = 1; Data.money < BigInteger.Pow(10,68+i); i++){
        moneytext.text = string.Format("{0:0}×10^{1:0}",
        Data.money/BigInteger.Pow(10,53+i), 53+i);
        }
        */
    }
}
