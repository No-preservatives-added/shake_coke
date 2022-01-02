using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class CountShake : MonoBehaviour
{
    public GameObject master;
    public Text ShakeCount;
    public double Magnificant;

    // Start is called before the first frame update
    void Start()
    {
        Data.ShakeCount = 0;
        Data.ImaginaryShakeCount = 0;

        Magnificant = 300-((300-30)*(((double)Data.MagnificationLevel-1)/50+1))/(Math.Exp(((double)Data.MagnificationLevel-1)/50));
    }

    // Update is called once per frame
    void Update()
    {
        ShakeCount.text=string.Format("{0:0}", Data.ShakeCount);
    }

    public void IncrementShake()
    {
        // 有効時間内か確認
        if(master.GetComponent<MyTimer>().isRemainTimeUsing){
            Data.ShakeCount += 1;
            Data.ImaginaryShakeCount += 1;
        }else if(master.GetComponent<MyTimer>().isStopTimeUsing){
            Data.ShakeCount += 1;
            Data.ImaginaryShakeCount += (int)Magnificant;
        }
        Debug.Log(Data.ImaginaryShakeCount);

    }
}
