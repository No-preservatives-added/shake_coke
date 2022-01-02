using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject master,Item;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onClickAct() {

        if(Data.StopLevel < 11){
            master.GetComponent<MyTimer>().StopTime=Data.StopTime+0.1f*(Data.StopLevel-1);
        }
        
        else if(Data.StopLevel < 31){
            master.GetComponent<MyTimer>().StopTime=2.0f+0.05f*(Data.StopLevel-10);
        } 
        
        else if(Data.StopLevel < 131){
            master.GetComponent<MyTimer>().StopTime=3.0f+0.01f*(Data.StopLevel-30);
        }

        else if(Data.StopLevel < 331){
            master.GetComponent<MyTimer>().StopTime=4.0f+0.005f*(Data.StopLevel-130);
        }
        
        else{
             master.GetComponent<MyTimer>().StopTime=5.0f+0.001f*(Data.StopLevel-1536);
        }

        master.GetComponent<MyTimer>().isRemainTimeUsing = false;
        master.GetComponent<MyTimer>().isStopTimeUsing = true;
        Item.SetActive(false);

    }
}
