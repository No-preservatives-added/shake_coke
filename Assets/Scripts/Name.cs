using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour
{
    public static string NameChange(string s){
        string name = "";

        if(s=="きよの"){
            name="みつお";
        }else if(s=="みつお"){
            name="きよの";
        }else{
            name="きよのみつお";
        }

        return name;
    }
}
