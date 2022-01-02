using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class Result : MonoBehaviour
{
    public Text MoneyText, ElectricPowerGenerationText, InternalPressureText, SecondText, ShakeCountText;
    private BigInteger ElectricPowerGeneration, Money;
    private BigInteger InternalPressure;
    private BigInteger CurrentElectricPowerGeneration, CurrentMoney;
    private double CurrentElectricPowerGenerationsmall, CurrentMoneysmall;
    private float WaitTime;
    private string moneyString = "";
    private int moneyStringLength = 0;
    private int moneyOffset = 0;
    private string ElectricPowerGenerationString = "";
    private int ElectricPowerGenerationStringLength = 0;
    private int ElectricPowerGenerationOffset = 0;
    private int unitNum = 0;
    private string[] unitList = new string[] { "", "万", "億", "兆", "京", "垓", "𥝱", "穣", "溝", "澗", "正", "載", "極", "恒河沙", "阿僧祇", "那由他", "不可思議","無量大数"};
    // Start is called before the first frame update
    void Start()
    {
        WaitTime = 0.0f;
        CurrentMoney = 0;
        InternalPressure = BigInteger.Pow(Data.CokeLevel,2) * Data.ImaginaryShakeCount;

        /*
        InternalPressure = Math.Pow(1.1, (Data.CokeLevel - 1)) * Data.ShakeCount;

        ElectricPowerGeneration = InternalPressure * ((double)(1 +((Data.WaterWheelLevel)- 1)*3) / 100) * Math.Pow(5.0, 1 +(((Data.DynamoLevel)- 1)- 1))*10.0;

        ElectricPowerGeneration = (InternalPressure * Math.Pow(5.0, Data.DynamoLevel - 1) + Math.Pow(1.1, Data.WaterWheelLevel - 1))/10;

        ElectricPowerGeneration = (InternalPressure + Math.Pow(1.5, Data.WaterWheelLevel - 1)) * Math.Pow(5.0, Data.DynamoLevel - 1)/10;
        */

        ElectricPowerGeneration =  InternalPressure*BigInteger.Pow(Data.WaterWheelLevel,3)*BigInteger.Pow(10,(Data.DynamoLevel-1)*20);

        CurrentElectricPowerGeneration = ElectricPowerGeneration;
        CurrentElectricPowerGenerationsmall = (double)ElectricPowerGeneration;
        Money = ElectricPowerGeneration;
        MoneyText.text = string.Format("獲得金額:{0}円", CurrentMoney);
        
        if(ElectricPowerGeneration <= 10000){
            ElectricPowerGenerationText.text = string.Format("発電量:{0}kw", CurrentElectricPowerGeneration);
        }else{
            ElectricPowerGenerationString = CurrentElectricPowerGeneration.ToString("0"); //文字列変換
            ElectricPowerGenerationStringLength = ElectricPowerGenerationString.Length; //文字数カウント
            //Debug.Log(ElectricPowerGenerationString+","+ElectricPowerGenerationStringLength); //確認

            if (ElectricPowerGenerationStringLength < 73){ //無量大数までの単位で表せる
                ElectricPowerGenerationOffset = (ElectricPowerGenerationStringLength+3)%4+1; //最初の単位までの桁計算1-4
                unitNum = (int)(ElectricPowerGenerationStringLength+3)/4-1; //単位の数
                ElectricPowerGenerationText.text = ElectricPowerGenerationString.Substring(0, ElectricPowerGenerationOffset)+unitList[unitNum]; //表示文字列=最初の単位までの数字+最初の単位
                for (int i=unitNum;i>0;i--) {
                    ElectricPowerGenerationText.text += ElectricPowerGenerationString.Substring(ElectricPowerGenerationOffset+4*(unitNum-i), 4)+unitList[i-1]; //表示文字列に（単位までの数字+単位）を追加
                    if ((unitNum-i) == 0) break; //単位を2回出力したらやめる
                }
            }else{ //無量大数より大きい
                ElectricPowerGenerationText.text += ElectricPowerGenerationString.Substring(0, 1)+"."+ElectricPowerGenerationString.Substring(1, 8)+"×10^"+(ElectricPowerGenerationStringLength-1); //1桁.8桁×10^(文字数-1)
            }
            ElectricPowerGenerationText.text += "kw"; //表示文字列に円を追加
            ElectricPowerGenerationText.text = ElectricPowerGenerationText.text.Insert(0,"発電量:");
        }

        ShakeCountText.text = string.Format("振った回数:{0}回", Data.ShakeCount);
        InternalPressureText.text = string.Format("最終的な内圧:{0:0}Pa", InternalPressure);
        SecondText.text = string.Format("振った秒数:{0:0.00}秒",Data.ShakeTime);

        Data.money += Money;

        SaveLoad.Save();

    }

    // Update is called once per frame
    void Update()
    {
        if (WaitTime < 2.0f)
        {
            WaitTime += Time.deltaTime;
        }

        else
        {
            if(ElectricPowerGeneration <= 10000){
                if (CurrentElectricPowerGenerationsmall > 0){
                    CurrentElectricPowerGenerationsmall -= (double)ElectricPowerGeneration * (Time.deltaTime / 2.0f);
                }

                if (CurrentElectricPowerGenerationsmall <= 0){
                    CurrentElectricPowerGenerationsmall = (double)0;
                }
                
                ElectricPowerGenerationText.text = string.Format("発電量:{0:0.00}kw", CurrentElectricPowerGenerationsmall);
            }else{
                if (CurrentElectricPowerGeneration > 0){
                    CurrentElectricPowerGeneration -= ElectricPowerGeneration / (BigInteger)(2.0f / Time.deltaTime);
                }

                if (CurrentElectricPowerGeneration <= 0){
                    CurrentElectricPowerGeneration = 0;
                }

            ElectricPowerGenerationString = CurrentElectricPowerGeneration.ToString("0"); //文字列変換
            ElectricPowerGenerationStringLength = ElectricPowerGenerationString.Length; //文字数カウント
            //Debug.Log(ElectricPowerGenerationString+","+ElectricPowerGenerationStringLength); //確認

            if (ElectricPowerGenerationStringLength < 73){ //無量大数までの単位で表せる
                ElectricPowerGenerationOffset = (ElectricPowerGenerationStringLength+3)%4+1; //最初の単位までの桁計算1-4
                unitNum = (int)(ElectricPowerGenerationStringLength+3)/4-1; //単位の数
                ElectricPowerGenerationText.text = ElectricPowerGenerationString.Substring(0, ElectricPowerGenerationOffset)+unitList[unitNum]; //表示文字列=最初の単位までの数字+最初の単位
                for (int i=unitNum;i>0;i--) {
                    ElectricPowerGenerationText.text += ElectricPowerGenerationString.Substring(ElectricPowerGenerationOffset+4*(unitNum-i), 4)+unitList[i-1]; //表示文字列に（単位までの数字+単位）を追加
                    if ((unitNum-i) == 0) break; //単位を2回出力したらやめる
                }
            }else{ //無量大数より大きい
                ElectricPowerGenerationText.text = ElectricPowerGenerationString.Substring(0, 1)+"."+ElectricPowerGenerationString.Substring(1, 8)+"×10^"+(ElectricPowerGenerationStringLength-1); //1桁.8桁×10^(文字数-1)
            }
            ElectricPowerGenerationText.text += "kw"; //表示文字列に円を追加
            ElectricPowerGenerationText.text = ElectricPowerGenerationText.text.Insert(0,"発電量:");
            }

            if(Money <= 10000){
                if (CurrentMoneysmall < (double)Money){
                    CurrentMoneysmall += (double)Money * (Time.deltaTime / 2.0f);
                }

                if (CurrentMoneysmall >= (double)Money){
                    CurrentMoneysmall = (double)Money;
                }

                MoneyText.text = string.Format("獲得金額:{0:0}円", CurrentMoneysmall);
            }else{
                
                if (CurrentMoney < Money){
                    CurrentMoney += Money / (BigInteger)(2.0f / Time.deltaTime);
                }

                if (CurrentMoney >= Money){
                    CurrentMoney = Money;
                }
            
            moneyString = CurrentMoney.ToString("0"); //文字列変換
            moneyStringLength = moneyString.Length; //文字数カウント
            //Debug.Log(moneyString+","+moneyStringLength); //確認

            if (moneyStringLength < 73){ //無量大数までの単位で表せる
                moneyOffset = (moneyStringLength+3)%4+1; //最初の単位までの桁計算1-4
                unitNum = (int)(moneyStringLength+3)/4-1; //単位の数
                MoneyText.text = moneyString.Substring(0, moneyOffset)+unitList[unitNum]; //表示文字列=最初の単位までの数字+最初の単位
                for (int i=unitNum;i>0;i--) {
                    MoneyText.text += moneyString.Substring(moneyOffset+4*(unitNum-i), 4)+unitList[i-1]; //表示文字列に（単位までの数字+単位）を追加
                    if ((unitNum-i) == 0) break; //単位を2回出力したらやめる
                }
            }else{ //無量大数より大きい
                MoneyText.text = moneyString.Substring(0, 1)+"."+moneyString.Substring(1, 8)+"×10^"+(moneyStringLength-1); //1桁.8桁×10^(文字数-1)
            }
            MoneyText.text += "円"; //表示文字列に円を追加
            MoneyText.text = MoneyText.text.Insert(0,"獲得金額:");
            }
        }
    }
}
