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


        CokeCostText.text = $"NEED {Data.CokeCost.ToString()} MONEY";
        BottleCostText.text = $"NEED {Data.BottleCost.ToString()} MONEY";
        WaterWheelCostText.text = $"NEED {Data.WaterWheelCost.ToString()} MONEY";
        DynamoCostText.text = $"NEED {Data.DynamoCost.ToString()} MONEY";
        ProbabilityCostText.text = $"NEED {Data.ProbabilityCost.ToString()} MONEY";
        StopCostText.text = $"NEED {Data.StopCost.ToString()} MONEY";
        MagnificationCostText.text = $"NEED {Data.MagnificationCost.ToString()} MONEY";
    }
}
