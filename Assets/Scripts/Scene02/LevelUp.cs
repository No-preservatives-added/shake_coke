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
        /*Data.CokeCost = (ulong)(Data.DefaultCokeCost*Math.Pow(1.05,(Data.CokeLevel-1)));*/

        if(Data.CokeLevel < 495){
        Data.CokeCost = (ulong)((ulong)Data.DefaultCokeCost + (ulong)Data.CokeLevel);
        }

        else{
        Data.DefaultCokeCost=+495;
        Data.CokeCost = (ulong)(Data.DefaultCokeCost*Math.Pow(1.001,((ulong)(Data.CokeLevel+9))));
        }

    } 
    public void BottleLevelUp()
    {
        Data.BottleLevel++;
        Data.money -= Data.BottleCost;

        /*if(Data.BottleLevel < 11){
        Data.BottleCost = (ulong)(Data.DefaultBottleCost*(1+0.25*(Data.BottleLevel-1)));
        }

        else if(Data.BottleLevel < 105){
        Data.BottleCost = (ulong)(Data.DefaultBottleCost*(1+0.5*(Data.BottleLevel-1))-500);
        }

        else if(Data.BottleLevel < 195){
        Data.BottleCost = (ulong)(Data.DefaultBottleCost*(1+5.0*(Data.BottleLevel-1))-93200);
        }

        else{
        Data.BottleCost = (ulong)(Data.DefaultBottleCost*Math.Pow(1.05,(Data.BottleLevel-1))-2470798);
        }*/
        
        if(Data.BottleLevel < 7){
        Data.BottleCost = (ulong)((ulong)Data.DefaultBottleCost+50*((ulong)Data.BottleLevel-1));
        }

        else if(Data.BottleLevel < 17){ 
        Data.BottleCost = (ulong)(500+100*(Data.BottleLevel-6));
        }
        
        else if(Data.BottleLevel < 27){
        Data.BottleCost = (ulong)(1500+150*(Data.BottleLevel-16));
        }

        else if(Data.BottleLevel < 47){
        Data.BottleCost = (ulong)(3000+200*(Data.BottleLevel-26));
        }

        else if(Data.BottleLevel < 87){
        Data.BottleCost = (ulong)(7000+250*(Data.BottleLevel-46));
        }

        else if(Data.BottleLevel < 187){
        Data.BottleCost = (ulong)(17000+300*(Data.BottleLevel-86));
        }

        else if(Data.BottleLevel < 287){
        Data.BottleCost = (ulong)(47000+350*(Data.BottleLevel-186));
        }

        else if(Data.BottleLevel < 787){
        Data.BottleCost = (ulong)(82000+500*(Data.BottleLevel-286));
        }

        else if(Data.BottleLevel < 1537){
        Data.BottleCost = (ulong)(332000+1000*(Data.BottleLevel-786));
        }

        else{
        Data.BottleCost = (ulong)((ulong)1083000*Math.Pow(1.05,(Data.BottleLevel-1536)));
        }
        
    }
    public void WaterWheelLevelUp()
    {
        Data.WaterWheelLevel++;
        Data.money -= Data.WaterWheelCost;
        /*Data.WaterWheelCost = (ulong)(Data.DefaultWaterWheelCost*(1+0.5*(Data.WaterWheelLevel-1)));*/

        Data.WaterWheelCost = (ulong)(Data.DefaultWaterWheelCost*Math.Pow(1.002,((ulong)(Data.WaterWheelLevel-1))));


    }
    public void DynamoLevelUp()
    {
        Data.DynamoLevel++;
        Data.money -= Data.DynamoCost;
        if(Data.BottleLevel < 5){
        Data.DynamoCost = (ulong)(Data.DefaultDynamoCost*Math.Pow(1000,(Data.DynamoLevel-1)));
        }

        else{
        Data.DefaultDynamoCost=Data.DefaultDynamoCost*1000000;
        Data.DynamoCost = (ulong)(Data.DefaultDynamoCost*((ulong)Data.DynamoLevel-3));
        }
        
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
