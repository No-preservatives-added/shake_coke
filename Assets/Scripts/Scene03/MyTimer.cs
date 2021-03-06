using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour
{
    public bool isMarginTimeUsing=false;
    public bool isRemainTimeUsing=false;
    public bool isStopTimeUsing=false;

    public Text MarginTimeText;
    public Text RemainTimeText;
    public Text StopTimeText;
    public GameObject StopTimeObject;
    [SerializeField] private GameObject PushButton;
    [SerializeField] private GameObject ShakePanel;

    public float StopTime;
    private float RemainTime;
    private float MarginTime;
    // Start is called before the first frame update
    private float ShakeTime;
    void Start()
    {
        isMarginTimeUsing=true;
        StopTimeObject.SetActive(false);

        if(Data.BottleLevel < 7){
            RemainTime=Data.RemainTime+1.0f*(Data.BottleLevel-1);
        }

        else if(Data.BottleLevel < 17){
            RemainTime=8.0f+0.7f*(Data.BottleLevel-6);
        }

        else if(Data.BottleLevel < 27){
            RemainTime=15.0f+0.5f*(Data.BottleLevel-16);
        }

        else if(Data.BottleLevel < 47){
            RemainTime=20.0f+0.2f*(Data.BottleLevel-26);
        }

        else if(Data.BottleLevel < 87){
            RemainTime=24.0f+0.1f*(Data.BottleLevel-46);
        }

        else if(Data.BottleLevel < 187){
            RemainTime=28.0f+0.07f*(Data.BottleLevel-86);
        }

        else if(Data.BottleLevel < 287){
            RemainTime=35.0f+0.05f*(Data.BottleLevel-106);
        }

        else if(Data.BottleLevel < 787){
            RemainTime=40.0f+0.03f*(Data.BottleLevel-286);
        }

        else if(Data.BottleLevel < 1537){
            RemainTime=45.0f+0.02f*(Data.BottleLevel-786);
        }

        else{
            RemainTime=60.0f+0.01f*(Data.BottleLevel-1536);
        }

        MarginTime=Data.MarginTime;
        ShakeTime = 0.0f;

        Data.StopTime= (float)(5-((5-1)*(((double)Data.StopLevel-1)/20+1))/(Math.Exp(((double)Data.StopLevel-1)/20)));
    }

    // Update is called once per frame
    void Update()
    {
        if(isRemainTimeUsing){ // ????????????
            RemainTime-=Time.deltaTime;
            ShakeTime += Time.deltaTime;
            //Debug.Log("RemainTime = "+Data.RemainTime);
            if(RemainTime<0.0f){
                isRemainTimeUsing=false;
                Debug.Log("??????");
                //???????????????????????????
                MarginTimeText.enabled = true; // "??????"??????
                MarginTime=1.0f;
                isMarginTimeUsing=true; // 1?????????
            }
        }else if(isStopTimeUsing){ // ??????????????????????????????????????????
            StopTime-=Time.deltaTime;
            ShakeTime += Time.deltaTime;
            //Debug.Log("StopTime = "+StopTime);
            if(StopTime<0.0f){
                isStopTimeUsing=false;
                isRemainTimeUsing=true; // ?????????????????????
                StopTime=Data.StopTime;
            }
        }else if(isMarginTimeUsing){ // ?????????????????????
            MarginTime-=Time.deltaTime;
            //Debug.Log("MarginTime = "+MarginTime);
            if(MarginTime<0.0f){
                if(RemainTime>0.0f){ //3,2,1,0???????????????????????????
                    MarginTimeText.enabled = false;
                    isMarginTimeUsing=false;
                    isRemainTimeUsing=true; // ?????????????????????
                }else{ //????????????
                    RemainTime = 0.0f;
                    MarginTimeText.enabled = false;
                    isMarginTimeUsing=false;
                    PushButton.SetActive(false);// Push???????????????
                    ShakePanel.SetActive(false);// ??????????????????
                    Data.ShakeTime = ShakeTime;
                    StartCoroutine(this.GetComponent<BottleOpen>().ZoomToCokeBottle()); //????????????????????????????????????
                }
            }
        }

        // ??????????????????
        if(RemainTime>0.0f){
            MarginTimeText.text=string.Format("{0:0}", Mathf.Ceil(MarginTime));
        }else{
            MarginTimeText.text=string.Format("??????");
        }
        RemainTimeText.text=string.Format("???????????? : {0:0.00} ???", RemainTime);

        if(isStopTimeUsing){
            StopTimeObject.SetActive(true);
            StopTimeText.text=string.Format("?????????????????? : {0:0.00} ???", StopTime);
        }else{
            StopTimeObject.SetActive(false);
        }
    }


}
