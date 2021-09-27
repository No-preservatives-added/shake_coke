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
    [SerializeField] private GameObject PushButton;


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
            RemainTime=3.0f+1.0f*(Data.BottleLevel-1);
        }
        
        else if(Data.BottleLevel < 17){
            RemainTime=8.0f+0.9f*(Data.BottleLevel-6);
        } 
        
        else if(Data.BottleLevel < 27){
            RemainTime=17.0f+0.8f*(Data.BottleLevel-16);
        }

        else if(Data.BottleLevel < 47){
            RemainTime=25.0f+0.7f*(Data.BottleLevel-26);
        }

        else if(Data.BottleLevel < 67){
            RemainTime=39.0f+0.6f*(Data.BottleLevel-46);
        }

        else if(Data.BottleLevel < 107){
            RemainTime=51.0f+0.5f*(Data.BottleLevel-66);
        }

        else if(Data.BottleLevel < 147){
            RemainTime=71.0f+0.4f*(Data.BottleLevel-106);
        }

        else if(Data.BottleLevel < 227){
            RemainTime=87.0f+0.3f*(Data.BottleLevel-146);
        }

        else if(Data.BottleLevel < 307){
            RemainTime=111.0f+0.2f*(Data.BottleLevel-226);
        }

        else{
            RemainTime=137.0f+0.1f*(Data.BottleLevel-1);
        }

        MarginTime=Data.MarginTime;
        ShakeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRemainTimeUsing){ // 残り時間
            RemainTime-=Time.deltaTime;
            ShakeTime += Time.deltaTime;
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
            ShakeTime += Time.deltaTime;
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
                    RemainTime = 0.0f;
                    MarginTimeText.enabled = false;
                    isMarginTimeUsing=false;
                    PushButton.SetActive(false);// Pushボタン消去
                    Data.ShakeTime = ShakeTime;
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
