using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAvailable : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject coke_button, bottle_button, waterwheel_button, dynamo_button;

    void Start()
    {
        coke_button = GameObject.Find("CokeLevelButton");
        bottle_button = GameObject.Find("BottleLevelButton");
        waterwheel_button = GameObject.Find("WaterWheelLevelButton");
        dynamo_button = GameObject.Find("DynamoLevelButton");
    }

    // Update is called once per frame
    void Update()
    {
        if(Data.money>=Data.CokeCost){
            coke_button.SetActive (true);
        }else{
            coke_button.SetActive (false);
        }
        if(Data.money>=Data.BottleCost){
            bottle_button.SetActive (true);
        }else{
            bottle_button.SetActive (false);
        }
        if(Data.money>=Data.WaterWheelCost){
            waterwheel_button.SetActive (true);
        }else{
            waterwheel_button.SetActive (false);
        }
        if(Data.money>=Data.DynamoCost){
            dynamo_button.SetActive (true);
        }else{
            dynamo_button.SetActive (false);
        }
    }
}
