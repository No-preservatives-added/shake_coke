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
        InternalPressure = BigInteger.Pow(Data.CokeLevel,2) * Data.ShakeCount;

        /*
        InternalPressure = Math.Pow(1.1, (Data.CokeLevel - 1)) * Data.ShakeCount;
        
        ElectricPowerGeneration = InternalPressure * ((double)(1 +((Data.WaterWheelLevel)- 1)*3) / 100) * Math.Pow(5.0, 1 +(((Data.DynamoLevel)- 1)- 1))*10.0;
        
        ElectricPowerGeneration = (InternalPressure * Math.Pow(5.0, Data.DynamoLevel - 1) + Math.Pow(1.1, Data.WaterWheelLevel - 1))/10;
        
        ElectricPowerGeneration = (InternalPressure + Math.Pow(1.5, Data.WaterWheelLevel - 1)) * Math.Pow(5.0, Data.DynamoLevel - 1)/10;
        */

        ElectricPowerGeneration =  InternalPressure*BigInteger.Pow(Data.WaterWheelLevel,3)*BigInteger.Pow(Data.DynamoLevel,100);

        CurrentElectricPowerGeneration = ElectricPowerGeneration;
        CurrentElectricPowerGenerationsmall = (double)ElectricPowerGeneration;       
        Money = ElectricPowerGeneration;             
        MoneyText.text = string.Format("獲得金額:{0}円", CurrentMoney);
        ElectricPowerGenerationText.text = string.Format("発電量:{0}kw", CurrentElectricPowerGeneration);
        ShakeCountText.text = string.Format("振った回数:{0}回", Data.ShakeCount);
        InternalPressureText.text = string.Format("最終的な内圧:{0:0}Pa", InternalPressure);
        SecondText.text = string.Format("振った秒数:{0:0.00}秒",Data.ShakeTime);

        Data.money += Money;

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
            if(ElectricPowerGeneration < 1000){
            if (CurrentElectricPowerGenerationsmall > 0)
            {
                CurrentElectricPowerGenerationsmall -= (double)ElectricPowerGeneration * (Time.deltaTime / 2.0f);
            }
            
            if (CurrentElectricPowerGenerationsmall <= 0)
            {
                CurrentElectricPowerGenerationsmall = (double)0;
            }
            
            ElectricPowerGenerationText.text = string.Format("発電量:{0:0.00}kw", CurrentElectricPowerGenerationsmall);

            }

            if(Money < 1000){

            if (CurrentMoneysmall < (double)Money)
            {
                 CurrentMoneysmall += (double)Money * (Time.deltaTime / 2.0f);
            }
            
            if (CurrentMoneysmall >= (double)Money)
            {
                CurrentMoneysmall = (double)Money;
            }

            MoneyText.text = string.Format("獲得金額:{0:0}円", CurrentMoneysmall);          
            
            }

            
            else{
            if (CurrentElectricPowerGeneration > 0)
            {
                CurrentElectricPowerGeneration -= ElectricPowerGeneration / (BigInteger)(2.0f / Time.deltaTime);
            }
            
            if (CurrentElectricPowerGeneration <= 0)
            {
                CurrentElectricPowerGeneration = 0;
            }
            
            if (CurrentMoney < Money)
            {
                CurrentMoney += Money / (BigInteger)(2.0f / Time.deltaTime);
            }
            
            if (CurrentMoney >= Money)
            {
                CurrentMoney = Money;
            }

            MoneyText.text = string.Format("獲得金額:{0:0}円", CurrentMoney);

            ElectricPowerGenerationText.text = string.Format("発電量:{0:0}kw", CurrentElectricPowerGeneration);

            }
        }

        /*DOTween.To 
            (
                () => CurrentElectricPowerGeneration,       //何に
                (x) => CurrentElectricPowerGeneration = x,  //何を
                0,                                          //どこまで(最終的な値)
                1                                        //どれくらいの時間
            ).SetEase(Ease.Linear);

            DOTween.To 
            (
                () => CurrentMoney,         //何に
                (x) => CurrentMoney = x,    //何を
                Money,                      //どこまで(最終的な値)
                1                        //どれくらいの時間
            ).SetEase(Ease.Linear);*/

    }
}
