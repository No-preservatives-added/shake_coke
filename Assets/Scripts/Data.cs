using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    //定数の定義
    public static ulong DefaultCokeCost = 5;
    public static ulong DefaultBottleCost = 200;
    public static ulong DefaultWaterWheelCost = 100;
    public static ulong DefaultDynamoCost = 1000000;
    public static ulong DefaultProbabilityCost = 100000;
    public static ulong DefaultStopCost = 50000;
    public static ulong DefaultMagnificationCost = 1000000;




    public static ulong money = 0;
    public static double money_digit = 0;

    public static double moneydummy_information = 3.2d;
    public static int moneydummy_digit = 1;

    public static void MoneyAdder(double addmoney){
        int digit=0;
        while(addmoney>=10){
            addmoney/=10.0d;
            digit+=1;
        }
        if(moneydummy_digit>=digit){
            for(int i=0;i<moneydummy_digit-digit;i++){
                addmoney/=10.0d;
            }
            moneydummy_information += addmoney;
        }else{
            for(int i=0;i<digit-moneydummy_digit;i++){
                moneydummy_information/=10.0d;
            }
            moneydummy_information = addmoney + moneydummy_information;
            moneydummy_digit=digit;
        }

        if(moneydummy_information>=10){
            Debug.Log(moneydummy_information);
            moneydummy_information/=10.0d;
            moneydummy_digit++;
        }
    }

    public static int CokeLevel = 1;
    public static int BottleLevel = 1;
    public static int WaterWheelLevel = 1;
    public static int DynamoLevel = 1;
    public static int ProbabilityLevel = 1;
    public static int StopLevel = 1;
    public static int MagnificationLevel = 1;

    public static ulong AddCost = 10;
    public static ulong CokeCost = DefaultCokeCost;
    public static ulong BottleCost = DefaultBottleCost;
    public static ulong WaterWheelCost = DefaultWaterWheelCost;
    public static ulong DynamoCost = DefaultDynamoCost;
    public static ulong ProbabilityCost = DefaultProbabilityCost;
    public static ulong StopCost = DefaultStopCost;
    public static ulong MagnificationCost = DefaultMagnificationCost;

    public static int ShakeCount = 0;
    public static float ShakeTime = 0.0f;
    public static float MarginTime = 3.0f;
    public static float RemainTime = 3.0f;
    //public static float RemainTime=1.0f; // デバッグ用
    public static float StopTime = 5.0f;


}

