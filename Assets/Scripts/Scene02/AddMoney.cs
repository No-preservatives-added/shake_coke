using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class AddMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoneyUp(){
        Data.money+=BigInteger.Parse("12345678901234567890123456789012345678901234567890123456789012345678");
    }
}
