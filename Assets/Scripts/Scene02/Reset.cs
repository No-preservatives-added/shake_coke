using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public void LifeReset()
    {
        SaveLoad.Reset();
        SaveLoad.Load();
    }
}
