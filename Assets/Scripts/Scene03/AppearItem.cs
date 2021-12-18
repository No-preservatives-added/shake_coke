using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AppearItem : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject master;
    public bool ItemAppear = false;
    private double Probability = (100-(100-0.04)*(((double)Data.ProbabilityLevel-1)/200+1)/Math.Exp(((double)Data.ProbabilityLevel-1)/200))/100;
    public GameObject Item;
    private float WaitTime=0;
    private double R;
    void Start(){
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        //if(master.GetComponent<MyTimer>().isRemainTimeUsing || master.GetComponent<MyTimer>().isStopTimeUsing){
        if(master.GetComponent<MyTimer>().isRemainTimeUsing){
            if(WaitTime>=0.2f){
                R = UnityEngine.Random.value;
                Debug.Log(R);
                WaitTime=0;
            }
            if(R<=Probability){
                Item.SetActive(true);
            }
        }else{
            Item.SetActive(false);
        }
        WaitTime+=Time.deltaTime;
    }
}