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
    [SerializeField] private GameObject waterwheelObject;
    [SerializeField] private float shakeSeconds=5.0f;

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

    public void RemoveCapStart(){ // ボタンが押された
        StartCoroutine(RotateMotion());// コルーチン実行
    }

    IEnumerator RotateMotion(){
        Debug.Log("RemoveCap");
        yield return StartCoroutine(RemoveCap());// コルーチン実行
        while (shakeSeconds>0.0f)
        {   
            if (shakeSeconds>0.2f){
                yield return StartCoroutine(RotateWaterwheel(0));
            }else{
                yield return StartCoroutine(RotateWaterwheel(1));
            }
            shakeSeconds-=0.2f;
            Debug.Log("shakeSeconds= "+shakeSeconds);
        }
        Debug.Log("show_result");
        this.gameObject.GetComponent<SceneSender>().SceneSend(); //シーン遷移
        yield return null;
    }
    
    IEnumerator RemoveCap(){
        openButton.SetActive(false);
        capObject.transform.DORotate(new Vector3(0,-1440,0), 1.5f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear); //キャップ回転
        capObject.transform.DOJump(new Vector3(0.75f, -1.0f, 0),1.5f, 1, 1.5f).SetEase(Ease.Linear).SetRelative(); //キャップジャンプ
        targetObject.transform.DORotate(new Vector3(0, 0, 90), 1.0f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear); //ボトル横向き
        Vector3 targetPosition = targetObject.transform.position + new Vector3 (-2.0f, 0.0f, 0.0f); //カメラが向く方向をボトルの2だけ左に設定
        var rotation = Quaternion.LookRotation(targetPosition - _camera.transform.position); //現在のカメラの方向とターゲットの方向の差
        _camera.transform.DORotateQuaternion(rotation, 1.0f); // 指定方向を向く
        _camera.DOFieldOfView(50, 1.0f).SetEase(Ease.OutSine); // カメラzoomアウト
        waterwheelObject.transform.DOMove(new Vector3(-2.8f, 2.0f, 0), 1.0f).SetEase(Ease.Linear); // 水車近付く
        yield return new WaitForSeconds(2.0f);
        //this.gameObject.GetComponent<SceneSender>().SceneSend(); //シーン遷移
    }
    IEnumerator RotateWaterwheel(int phase){
        if (phase == 0){
            _camera.transform.position=new Vector3(0f, 1f, -10f); //元の位置に戻す
            waterwheelObject.transform.DORotate(new Vector3(0,0,-180), 0.2f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear); //水車回転継続
            _camera.DOFieldOfView(35, 0.2f); //zoom
            _camera.transform.DOShakePosition(1f, 0.1f, 30, 1, false, false);
            yield return new WaitForSeconds(0.2f);
        }else if (phase == 1){
            waterwheelObject.transform.DORotate(new Vector3(0,0,-900), 2.0f, RotateMode.LocalAxisAdd); //水車回転終了
            _camera.DOFieldOfView(50, 2.0f); //zoom
            _camera.transform.DOMove(new Vector3(0f, 1f, -10f), 2.0f); //元の位置に戻す
            yield return new WaitForSeconds(2.0f);
        }
        
        
    }

    private IEnumerator DelayCoroutine(float waittime){
        yield return new WaitForSeconds(waittime);
    }
}
