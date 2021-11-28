using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTouch : MonoBehaviour
{
    //private int touchCount = 0;

    [SerializeField] private GameObject master;
    [SerializeField] private GameObject bottle;

    // Start is called before the first frame update
    void Start()
    {
        // text = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var fingerNum = Input.touchCount;
        // Debug.Log("fingerNum = " + fingerNum);


        for (var i = 0; i < fingerNum; i++)
        {
            var finger = Input.GetTouch(i);
            switch (finger.phase)
            {
                case TouchPhase.Began:
                    // 
                    master.GetComponent<CountShake>().IncrementShake();
                    bottle.GetComponent<ShakeMotion>().DoShake();
                    break;
                case TouchPhase.Moved:
                    // 
                    break;
                case TouchPhase.Stationary:
                    // 
                    break;
                case TouchPhase.Ended:
                    // 
                    break;
                case TouchPhase.Canceled:
                    // 
                    break;
            }
            
        }
        
        
    }
}
