using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAvailable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coke_button, bottle_button, waterwheel_button, dynamo_button, probability_button, stop_button, magnification_button;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Data.money >= Data.CokeCost)
        {
            coke_button.SetActive(true);
        }
        else
        {
            coke_button.SetActive(false);
        }
        if (Data.money >= Data.BottleCost)
        {
            bottle_button.SetActive(true);
        }
        else
        {
            bottle_button.SetActive(false);
        }
        if (Data.money >= Data.WaterWheelCost)
        {
            waterwheel_button.SetActive(true);
        }
        else
        {
            waterwheel_button.SetActive(false);
        }
        if (Data.money >= Data.DynamoCost)
        {
            dynamo_button.SetActive(true);
        }
        else
        {
            dynamo_button.SetActive(false);
        }
        if (Data.money >= Data.ProbabilityCost)
        {
            probability_button.SetActive(true);
        }
        else
        {
            probability_button.SetActive(false);
        }
        if (Data.money >= Data.StopCost)
        {
            stop_button.SetActive(true);
        }
        else
        {
            stop_button.SetActive(false);
        }
        if (Data.money >= Data.MagnificationCost)
        {
            magnification_button.SetActive(true);
        }
        else
        {
            magnification_button.SetActive(false);
        }
    }
}
