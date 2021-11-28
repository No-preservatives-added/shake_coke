using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableElements : MonoBehaviour
{
    [SerializeField] private GameObject element_1;

    // Start is called before the first frame update
    void Start()
    {
        element_1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
