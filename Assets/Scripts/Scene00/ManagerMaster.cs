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
        StartCoroutine(LoadYourAsyncScene());
    }

    // Update is called once per frame
    void Update()
    {
        // Press the space key to start coroutine
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Use a coroutine to load the Scene in the background
            // StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("01_Start",LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        //while (!asyncLoad.isDone)
        //{
            yield return null;
        //}
    }

    public void OnLoadSceneAdditive()
    {
        //01_Startを加算ロード。現在のシーンは残ったままで、01_Startが追加される
        SceneManager.LoadScene("01_Start",LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("02_Menu",LoadSceneMode.Additive);
        return;
    }
}
