using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelUp : MonoBehaviour
{
    public void CokeLevelUp(){
        Data.CokeLevel++;
        Data.money -= Data.CokeCost;
        Data.CokeCost += Data.AddCost;
    }
    public void BottleLevelUp(){
        Data.BottleLevel++;
        Data.money -= Data.BottleCost;
        Data.BottleCost += Data.AddCost;
    }
    public void WaterWheelLevelUp(){
        Data.WaterWheelLevel++;
        Data.money -= Data.WaterWheelCost;
        Data.WaterWheelCost += Data.AddCost;
    }
    public void DynamoLevelUp(){
        Data.DynamoLevel++;
        Data.money -= Data.DynamoCost;
        Data.DynamoCost += Data.AddCost;
    }
}
