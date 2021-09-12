using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class Result : MonoBehaviour
{
    public Text MoneyText, ElectricPowerGenerationText, InternalPressureText, SecondText, ShakeCountText;
    private int Money;
    private double ElectricPowerGeneration, InternalPressure, CurrentMoney;
    private double CurrentElectricPowerGeneration;
    private float WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        WaitTime = 0.0f;
        CurrentMoney = 0;
        InternalPressure = Math.Pow(1.1, (Data.CokeLevel - 1)) * Data.ShakeCount;
        ElectricPowerGeneration = InternalPressure * ((double)(Data.WaterWheelLevel)*3 / 100) * Math.Pow(1.0, ((Data.DynamoLevel)*50- 1))*10.0;
        CurrentElectricPowerGeneration = ElectricPowerGeneration;
        Money = (int)(10 * ElectricPowerGeneration);
        MoneyText.text = string.Format("獲得金額:{0}円", CurrentMoney);
        ElectricPowerGenerationText.text = string.Format("発電量:{0}kw", CurrentElectricPowerGeneration);
        ShakeCountText.text = string.Format("振った回数:{0}回", Data.ShakeCount);
        InternalPressureText.text = string.Format("最終的な内圧:{0:0.000}Pa", InternalPressure);
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
            if (CurrentElectricPowerGeneration > 0)
            {
                CurrentElectricPowerGeneration -= ElectricPowerGeneration * (Time.deltaTime / 2.0f);
            }
            if (CurrentElectricPowerGeneration <= 0)
            {
                CurrentElectricPowerGeneration = 0;
            }
            if (CurrentMoney < Money)
            {
                CurrentMoney += Money * (Time.deltaTime / 2.0f);
            }
            if (CurrentMoney >= Money)
            {
                CurrentMoney = Money;
            }
        }


        MoneyText.text = string.Format("獲得金額:{0:0}円", CurrentMoney);

        ElectricPowerGenerationText.text = string.Format("発電量:{0:0.00}kw", CurrentElectricPowerGeneration);

    }
}
