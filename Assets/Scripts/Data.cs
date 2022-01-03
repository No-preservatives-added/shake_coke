using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Data
{
    //定数の定義
    public static BigInteger DefaultCokeCost = 10;
    public static BigInteger DefaultBottleCost = 25000;
    public static BigInteger DefaultWaterWheelCost = 100;
    public static BigInteger DefaultDynamoCost = 200000000000;
    public static BigInteger DefaultProbabilityCost = 100000;
    public static BigInteger DefaultStopCost = 50000;
    public static BigInteger DefaultMagnificationCost = 1000000;





    public static BigInteger money = 0;

    public static int CokeLevel = 1;
    public static int BottleLevel = 1;
    public static int WaterWheelLevel = 1;
    public static int DynamoLevel = 1;
    public static int ProbabilityLevel = 1;
    public static int StopLevel = 1;
    public static int MagnificationLevel = 1;

    public static BigInteger AddCost = 10;
    public static BigInteger CokeCost = DefaultCokeCost;
    public static BigInteger BottleCost = DefaultBottleCost;
    public static BigInteger WaterWheelCost = DefaultWaterWheelCost;
    public static BigInteger DynamoCost = DefaultDynamoCost;
    public static BigInteger ProbabilityCost = DefaultProbabilityCost;
    public static BigInteger StopCost = DefaultStopCost;
    public static BigInteger MagnificationCost = DefaultMagnificationCost;

    public static int ShakeCount = 0;
    public static int ImaginaryShakeCount = 0;
    public static float ShakeTime = 0.0f;
    public static float MarginTime = 3.0f;
    public static float RemainTime = 3.0f;
    //public static float RemainTime=1.0f; // デバッグ用
    public static float StopTime = 1.0f;






    public static string Name="ふじた";


}
