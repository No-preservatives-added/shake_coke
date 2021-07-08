using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float MarginTime=3.0f;
    public float RemainTime=10.0f;
    public float StopTime=5.0f;
    private bool isMarginTimeUsing=false;
    private bool isRemainTimeUsing=false;
    private bool isStopTimeUsing=false;

    // Start is called before the first frame update
    void Start()
    {
        isMarginTimeUsing=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRemainTimeUsing){ // 残り時間
            RemainTime-=Time.deltaTime;
            Debug.Log("RemainTime = "+RemainTime);
            if(RemainTime<0.0f){
                isRemainTimeUsing=false;
                Debug.Log("発射");
                //発射に移るメソッド
            }
        }else if(isStopTimeUsing){ // ストップウォッチで止めた時間
            StopTime-=Time.deltaTime;
            Debug.Log("StopTime = "+StopTime);
            if(StopTime<0.0f){
                isStopTimeUsing=false;
                isRemainTimeUsing=true; // 残り時間を使う
            }
        }else if(isMarginTimeUsing){ // 最初のマージン
            MarginTime-=Time.deltaTime;
            Debug.Log("MarginTime = "+MarginTime);
            if(MarginTime<0.0f){
                isMarginTimeUsing=false;
                isRemainTimeUsing=true; // 残り時間を使う
            }
        }
        

    }

    void TimerStart()
    {

    }

    void TimerStop()
    {

    }
}
