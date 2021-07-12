using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeMotion : MonoBehaviour
{
    public GameObject master;
    private Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        sequence = DOTween.Sequence()
            .Append(this.transform.DOMoveY(1f, 0.05f).SetEase(Ease.Linear).SetRelative())
            .Append(this.transform.DOMoveY(-2f, 0.1f).SetEase(Ease.Linear).SetRelative())
            .Append(this.transform.DOMoveY(1.5f, 0.05f).SetEase(Ease.Linear))
            .Pause() // 自動再生させない
            .SetAutoKill(false) // 繰り返し使用可能
            .SetLink(this.gameObject); // 一緒にDestroyするgameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoShake()
    {
        if(master.GetComponent<MyTimer>().isRemainTimeUsing || master.GetComponent<MyTimer>().isStopTimeUsing){
            sequence.Restart();
        }
    }
}
