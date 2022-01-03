using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisp : MonoBehaviour
{
    // Start is called before the first frame update
    public Text CokeLevelText;
    public Text BottleLevelText;
    public Text WaterWheelLevelText;
    public Text DynamoLevelText;
    public Text ProbabilityLevelText;
    public Text StopLevelText;
    public Text MagnificationLevelText;
    public Text CokeCostText;
    public Text BottleCostText;
    public Text WaterWheelCostText;
    public Text DynamoCostText;
    public Text ProbabilityCostText;
    public Text StopCostText;
    public Text MagnificationCostText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CokeLevelText.text = Data.CokeLevel.ToString();
        BottleLevelText.text = Data.BottleLevel.ToString();
        WaterWheelLevelText.text = Data.WaterWheelLevel.ToString();
        DynamoLevelText.text = Data.DynamoLevel.ToString();
        ProbabilityLevelText.text = Data.ProbabilityLevel.ToString();
        StopLevelText.text = Data.StopLevel.ToString();
        MagnificationLevelText.text = Data.MagnificationLevel.ToString();


        CokeCostText.text = $"NEED {UnitDisplay.Display(Data.CokeCost)} MONEY";
        BottleCostText.text = $"NEED {UnitDisplay.Display(Data.BottleCost)} MONEY";
        WaterWheelCostText.text = $"NEED {UnitDisplay.Display(Data.WaterWheelCost)} MONEY";
        DynamoCostText.text = $"NEED {UnitDisplay.Display(Data.DynamoCost)} MONEY";
        ProbabilityCostText.text = $"NEED {UnitDisplay.Display(Data.ProbabilityCost)} MONEY";
        StopCostText.text = $"NEED {UnitDisplay.Display(Data.StopCost)} MONEY";
        MagnificationCostText.text = $"NEED {UnitDisplay.Display(Data.MagnificationCost)} MONEY";
    }
}
