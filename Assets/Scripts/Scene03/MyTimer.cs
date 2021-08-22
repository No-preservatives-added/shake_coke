using System.Collections;
using System.Collections.Generic;
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

    public float StopTime;
    private float RemainTime;
    private float MarginTime;
    // Start is called before the first frame update
    void Start()
    {
        isMarginTimeUsing=true;
        StopTimeObject.SetActive(false);
        RemainTime=Data.RemainTime;
        MarginTime=Data.MarginTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRemainTimeUsing){ // 残り時間
            RemainTime-=Time.deltaTime;
            //Debug.Log("RemainTime = "+Data.RemainTime);
            if(RemainTime<0.0f){
                isRemainTimeUsing=false;
                Debug.Log("発射");
                //発射に移るメソッド
                MarginTimeText.enabled = true; // "終了"表示
                MarginTime=1.0f;
                isMarginTimeUsing=true; // 1秒待つ
            }
        }else if(isStopTimeUsing){ // ストップウォッチで止めた時間
            StopTime-=Time.deltaTime;
            Debug.Log("StopTime = "+StopTime);
            if(StopTime<0.0f){
                isStopTimeUsing=false;
                isRemainTimeUsing=true; // 残り時間を使う
                StopTime=Data.StopTime;
            }
        }else if(isMarginTimeUsing){ // 最初のマージン
            MarginTime-=Time.deltaTime;
            Debug.Log("MarginTime = "+MarginTime);
            if(MarginTime<0.0f){
                if(RemainTime>0.0f){ //3,2,1,0のカウントダウン後
                    MarginTimeText.enabled = false;
                    isMarginTimeUsing=false;
                    isRemainTimeUsing=true; // 残り時間を使う
                }else{ //終了の後
                    MarginTimeText.enabled = false;
                    isMarginTimeUsing=false;
                    StartCoroutine(this.GetComponent<BottleOpen>().ZoomToCokeBottle()); //ボトル開栓アニメーション
                }
            }
        }

        // テキスト表示
        if(RemainTime>0.0f){
            MarginTimeText.text=string.Format("{0:0}", Mathf.Ceil(MarginTime));
        }else{
            MarginTimeText.text=string.Format("終了");
        }
        RemainTimeText.text=string.Format("残り時間 : {0:0.00} 秒", RemainTime);

        if(isStopTimeUsing){
            StopTimeObject.SetActive(true);
            StopTimeText.text=string.Format("停止残り時間 : {0:0.00} 秒", StopTime);
        }else{
            StopTimeObject.SetActive(false);
        }
    }


}
