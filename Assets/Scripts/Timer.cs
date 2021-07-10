using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // public float MarginTime=3.0f;
    // public float RemainTime=10.0f;
    // public float StopTime=5.0f;
    public bool isMarginTimeUsing=false;
    public bool isRemainTimeUsing=false;
    public bool isStopTimeUsing=false;

    public Text MarginTimeText;
    public Text RemainTimeText;


    // Start is called before the first frame update
    void Start()
    {
        isMarginTimeUsing=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRemainTimeUsing){ // 残り時間
            Data.RemainTime-=Time.deltaTime;
            Debug.Log("RemainTime = "+Data.RemainTime);
            if(Data.RemainTime<0.0f){
                isRemainTimeUsing=false;
                Debug.Log("発射");
                //発射に移るメソッド
            }
        }else if(isStopTimeUsing){ // ストップウォッチで止めた時間
            Data.StopTime-=Time.deltaTime;
            Debug.Log("StopTime = "+Data.StopTime);
            if(Data.StopTime<0.0f){
                isStopTimeUsing=false;
                isRemainTimeUsing=true; // 残り時間を使う
            }
        }else if(isMarginTimeUsing){ // 最初のマージン
            Data.MarginTime-=Time.deltaTime;
            Debug.Log("MarginTime = "+Data.MarginTime);
            if(Data.MarginTime<0.0f){
                MarginTimeText.enabled = false;
                isMarginTimeUsing=false;
                isRemainTimeUsing=true; // 残り時間を使う
            }
        }

        // テキスト表示
        MarginTimeText.text=string.Format("{0:0}", Mathf.Ceil(Data.MarginTime));
        RemainTimeText.text=string.Format("残り時間 : {0:0.00} 秒", Data.RemainTime);
        

    }

    void TimerStart()
    {

    }

    void TimerStop()
    {

    }
}
