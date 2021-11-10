using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Numerics;

public class LevelUp : MonoBehaviour
{

    public void CokeLevelUp()
    {
        Data.CokeLevel++;
        Data.money -= Data.CokeCost;
        /*Data.CokeCost = (BigInteger)(Data.DefaultCokeCost*Math.Pow(1.05,(Data.CokeLevel-1)));*/

        if(Data.CokeLevel < 495){
        Data.CokeCost = (BigInteger)((BigInteger)Data.DefaultCokeCost + (BigInteger)Data.CokeLevel);
        }

        else{
        Data.DefaultCokeCost=+495;
        Data.CokeCost = (BigInteger)(Data.DefaultCokeCost*BigInteger.Pow((Data.CokeLevel-494),2));
        }

    } 
    public void BottleLevelUp()
    {
        Data.BottleLevel++;
        Data.money -= Data.BottleCost;

        /*if(Data.BottleLevel < 11){
        Data.BottleCost = (BigInteger)(Data.DefaultBottleCost*(1+0.25*(Data.BottleLevel-1)));
        }

        else if(Data.BottleLevel < 105){
        Data.BottleCost = (BigInteger)(Data.DefaultBottleCost*(1+0.5*(Data.BottleLevel-1))-500);
        }

        else if(Data.BottleLevel < 195){
        Data.BottleCost = (BigInteger)(Data.DefaultBottleCost*(1+5.0*(Data.BottleLevel-1))-93200);
        }

        else{
        Data.BottleCost = (BigInteger)(Data.DefaultBottleCost*Math.Pow(1.05,(Data.BottleLevel-1))-2470798);
        }*/
        
        if(Data.BottleLevel < 7){
        Data.BottleCost = (BigInteger)((BigInteger)Data.DefaultBottleCost+50*((BigInteger)Data.BottleLevel-1));
        }

        else if(Data.BottleLevel < 17){ 
        Data.BottleCost = (BigInteger)(500+100*(Data.BottleLevel-6));
        }
        
        else if(Data.BottleLevel < 27){
        Data.BottleCost = (BigInteger)(1500+150*(Data.BottleLevel-16));
        }

        else if(Data.BottleLevel < 47){
        Data.BottleCost = (BigInteger)(3000+200*(Data.BottleLevel-26));
        }

        else if(Data.BottleLevel < 87){
        Data.BottleCost = (BigInteger)(7000+250*(Data.BottleLevel-46));
        }

        else if(Data.BottleLevel < 187){
        Data.BottleCost = (BigInteger)(17000+300*(Data.BottleLevel-86));
        }

        else if(Data.BottleLevel < 287){
        Data.BottleCost = (BigInteger)(47000+350*(Data.BottleLevel-186));
        }

        else if(Data.BottleLevel < 787){
        Data.BottleCost = (BigInteger)(82000+500*(Data.BottleLevel-286));
        }

        else if(Data.BottleLevel < 1537){
        Data.BottleCost = (BigInteger)(332000+1000*(Data.BottleLevel-786));
        }

        else{
        Data.BottleCost = (BigInteger)((BigInteger)1083000*BigInteger.Pow((Data.BottleLevel-1536),2));
        }
        
    }
    public void WaterWheelLevelUp()
    {
        Data.WaterWheelLevel++;
        Data.money -= Data.WaterWheelCost;
        /*Data.WaterWheelCost = (BigInteger)(Data.DefaultWaterWheelCost*(1+0.5*(Data.WaterWheelLevel-1)));*/
  
        Data.WaterWheelCost = (BigInteger)(Data.DefaultWaterWheelCost*BigInteger.Pow((Data.WaterWheelLevel-1),3));

    }
    public void DynamoLevelUp()
    {
        Data.DynamoLevel++;
        Data.money -= Data.DynamoCost;
        if(Data.BottleLevel < 5){
        Data.DynamoCost = (BigInteger)(Data.DefaultDynamoCost*BigInteger.Pow(1000,(Data.DynamoLevel-1)));
        }

        else{
        Data.DefaultDynamoCost=Data.DefaultDynamoCost*1000000;
        Data.DynamoCost = (BigInteger)(Data.DefaultDynamoCost*BigInteger.Pow((Data.DynamoLevel-4),2));
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
