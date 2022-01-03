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
    
    // Start is called before the first frame update
    void Start()
    {
        WaitTime = 0.0f;
        CurrentMoney = 0;
        InternalPressure = BigInteger.Pow(Data.CokeLevel,2) * Data.ImaginaryShakeCount;

        ElectricPowerGeneration =  InternalPressure*BigInteger.Pow(Data.WaterWheelLevel,3)*BigInteger.Pow(10,(Data.DynamoLevel-1)*20);

        CurrentElectricPowerGeneration = ElectricPowerGeneration;
        CurrentElectricPowerGenerationsmall = (double)ElectricPowerGeneration;
        Money = ElectricPowerGeneration;
        MoneyText.text = string.Format("獲得金額:{0}円", CurrentMoney);
        
        if(ElectricPowerGeneration <= 10000){
            ElectricPowerGenerationText.text = string.Format("発電量:{0}kw", CurrentElectricPowerGeneration);
        }else{
            ElectricPowerGenerationText.text = UnitDisplay.Display(CurrentElectricPowerGeneration);
            ElectricPowerGenerationText.text += "kw"; //表示文字列にkwを追加
            ElectricPowerGenerationText.text = ElectricPowerGenerationText.text.Insert(0,"発電量:");//表示文字列頭に発電量を追加
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
            ElectricPowerGenerationText.text = UnitDisplay.Display(CurrentElectricPowerGeneration);
            ElectricPowerGenerationText.text += "kw"; //表示文字列にkwを追加
            ElectricPowerGenerationText.text = ElectricPowerGenerationText.text.Insert(0,"発電量:");//表示文字列頭に発電量を追加
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
            MoneyText.text = UnitDisplay.Display(CurrentMoney);
            MoneyText.text += "円"; //表示文字列に円を追加
            MoneyText.text = MoneyText.text.Insert(0,"獲得金額:");//表示文字列頭に獲得金額を追加
            }
        }
    }
}
