using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountShake : MonoBehaviour
{
    private int shake;

    // Start is called before the first frame update
    void Start()
    {
        shake = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementShake()
    {
        shake += 1;
    }
}
