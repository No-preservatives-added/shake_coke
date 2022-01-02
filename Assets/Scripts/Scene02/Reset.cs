using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public void LifeReset()
    {
        SaveLoad.Reset();
        SaveLoad.Load();

        Data.CokeCost = Data.DefaultCokeCost;
        Data.BottleCost = Data.DefaultBottleCost;
        Data.WaterWheelCost = Data.DefaultWaterWheelCost;
        Data.DynamoCost = Data.DefaultDynamoCost;
        Data.ProbabilityCost = Data.DefaultProbabilityCost;
        Data.StopCost = Data.DefaultStopCost;
        Data.MagnificationCost = Data.DefaultMagnificationCost;
    }
}
