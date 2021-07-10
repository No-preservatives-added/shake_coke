using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountShake : MonoBehaviour
{
    public GameObject master;
    public Text ShakeCount;

    // Start is called before the first frame update
    void Start()
    {
        Data.shake = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShakeCount.text=string.Format("{0:0}", Data.shake);
    }

    public void IncrementShake()
    {
        // 有効時間内か確認
        if(master.GetComponent<Timer>().isRemainTimeUsing || master.GetComponent<Timer>().isStopTimeUsing){
            Data.shake += 1;
        }
        
    }
}
