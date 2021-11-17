using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Manage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();
        //this.gameObject.
        GetComponent<ObservableEventTrigger>()
            .OnPointerClickAsObservable()
            .Subscribe(_ =>
            {
                var manager = FindObjectOfType<SceneManagerWithCache>();
                manager.LoadScene("01_Start").Subscribe(s => print("loaded: " + s.sceneName));
            });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
