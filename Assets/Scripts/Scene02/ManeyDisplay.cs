using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManeyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneytext;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneytext.text = Data.money.ToString("0");
    }
}
