using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class SaveLoad
{
    private BigInteger Money;
    public static void Save(){
        //レベルの保存
        PlayerPrefs.SetInt ("CokeLevel", Data.CokeLevel);
        PlayerPrefs.SetInt ("BottleLevel", Data.BottleLevel);
        PlayerPrefs.SetInt ("WaterWheelLevel", Data.WaterWheelLevel);
        PlayerPrefs.SetInt ("DynamoLevel", Data.DynamoLevel);
        PlayerPrefs.SetInt ("ProbabilityLevel", Data.ProbabilityLevel);
        PlayerPrefs.SetInt ("StopLevel", Data.StopLevel);
        PlayerPrefs.SetInt ("MagnificationLevel", Data.MagnificationLevel);

        //お金を文字列に変換







        PlayerPrefs.Save ();
    }
}
