using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class LevelUp : MonoBehaviour
{

    public void CokeLevelUp()
    {
        Data.CokeLevel++;
        Data.money -= Data.CokeCost;
        Data.CokeCost = (int)(Data.DefaultCokeCost*Math.Pow(1.15,(Data.CokeLevel-1)));
    }
    public void BottleLevelUp()
    {
        Data.BottleLevel++;
        Data.money -= Data.BottleCost;
        Data.BottleCost = (int)(Data.DefaultBottleCost*(1+0.2*(Data.BottleLevel-1)));
    }
    public void WaterWheelLevelUp()
    {
        Data.WaterWheelLevel++;
        Data.money -= Data.WaterWheelCost;
        Data.WaterWheelCost = (int)(Data.DefaultWaterWheelCost*(1+0.5*(Data.WaterWheelLevel-1)));
    }
    public void DynamoLevelUp()
    {
        Data.DynamoLevel++;
        Data.money -= Data.DynamoCost;
        Data.DynamoCost = (int)(Data.DefaultDynamoCost*Math.Pow(1.15,(Data.DynamoLevel-1)));
    }

    public void ProbabilityLevelUp()
    {
        Data.ProbabilityLevel++;
        Data.money -= Data.ProbabilityCost;
        Data.ProbabilityCost += Data.AddCost;
    }

    public void StopLevelUp()
    {
        Data.StopLevel++;
        Data.money -= Data.StopCost;
        Data.StopCost += Data.AddCost;
    }

    public void MagnificationLevelUp()
    {
        Data.MagnificationLevel++;
        Data.money -= Data.MagnificationCost;
        Data.MagnificationCost += Data.AddCost;
    }
}
