using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class SaveLoad
{
    public static void Save(){
        string Money;
        //レベルの保存
        PlayerPrefs.SetInt ("CokeLevel", Data.CokeLevel);
        PlayerPrefs.SetInt ("BottleLevel", Data.BottleLevel);
        PlayerPrefs.SetInt ("WaterWheelLevel", Data.WaterWheelLevel);
        PlayerPrefs.SetInt ("DynamoLevel", Data.DynamoLevel);
        PlayerPrefs.SetInt ("ProbabilityLevel", Data.ProbabilityLevel);
        PlayerPrefs.SetInt ("StopLevel", Data.StopLevel);
        PlayerPrefs.SetInt ("MagnificationLevel", Data.MagnificationLevel);

        //お金を文字列に変換
        Money = Data.money.ToString();

        //お金の保存
        PlayerPrefs.SetString ("Money", Money);

        //playerprefsを保存
        PlayerPrefs.Save ();
    }

    public static void Load(){
        //レベルの読み込み
        Data.CokeLevel = PlayerPrefs.GetInt ("CokeLevel", 1);
        Data.BottleLevel = PlayerPrefs.GetInt ("BottleLevel", 1);
        Data.WaterWheelLevel = PlayerPrefs.GetInt ("WaterWheelLevel", 1);
        Data.DynamoLevel = PlayerPrefs.GetInt ("DynamoLevel", 1);
        Data.ProbabilityLevel = PlayerPrefs.GetInt ("ProbabilityLevel",1);
        Data.StopLevel = PlayerPrefs.GetInt ("StopLevel", 1);
        Data.MagnificationLevel = PlayerPrefs.GetInt ("MagnificationLevel", 1);

        //お金をBigintegerに変換して読み込み
        Data.money=BigInteger.Parse(PlayerPrefs.GetString ("Money", "0"));

    }
}
