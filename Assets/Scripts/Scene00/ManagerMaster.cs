using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.OnLoadSceneAdditive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoadSceneAdditive()
    {
        //01_Startを加算ロード。現在のシーンは残ったままで、01_Startが追加される
        SceneManager.LoadScene("01_Start",LoadSceneMode.Additive);
        SceneManager.LoadScene("02_Menu",LoadSceneMode.Additive);
    }
}
