using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BottleOpen : MonoBehaviour
{
    // インペクターから設定する
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject openButton;
    [SerializeField] private GameObject capObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ZoomToCokeBottle(){
        Vector3 targetPosition = targetObject.transform.position + new Vector3 (0.0f, 1.0f, 0.0f); //カメラが向く方向をボトルの少し上に設定
        var rotation = Quaternion.LookRotation(targetPosition - _camera.transform.position); //現在のカメラの方向とターゲットの方向の差
        _camera.transform.DORotateQuaternion(rotation, 0.5f); // キャップを向く
        _camera.DOFieldOfView(10, 0.5f).SetEase(Ease.InBack); // カメラzoom 
        yield return new WaitForSeconds(0.5f);
        openButton.SetActive(true);
    }

    public void RemoveCapStart(){ // ボタンが押されたらコルーチン実行
        StartCoroutine(RemoveCap());
    }
    public IEnumerator RemoveCap(){
        capObject.transform.DORotate(new Vector3(0,-1440,0), 1.5f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear); //キャップ回転
        capObject.transform.DOJump(new Vector3(0.75f, -1.0f, 0),1.5f,1,1.5f).SetEase(Ease.Linear).SetRelative(); //キャップジャンプ
        //ホワイトアウト？
        yield return new WaitForSeconds(1.5f);
        this.gameObject.GetComponent<SceneSender>().SceneSend(); //シーン遷移
    }

    
    private IEnumerator DelayCoroutine(float waittime){
        yield return new WaitForSeconds(waittime);
    }
}
