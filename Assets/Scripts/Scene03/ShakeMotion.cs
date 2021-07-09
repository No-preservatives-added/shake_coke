using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeMotion : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoShake()
    {
        // this.transform.DOMoveY(3f, 0.5f).SetRelative();
        var sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOMoveY(1f, 0.05f));
        sequence.Append(this.transform.DOMoveY(1f, 0.05f).SetEase(Ease.Linear).SetRelative());
        sequence.Append(this.transform.DOMoveY(-2f, 0.1f).SetEase(Ease.Linear).SetRelative());
        sequence.Append(this.transform.DOMoveY(1f, 0.05f).SetEase(Ease.Linear));
        sequence.Play();
    }
}
