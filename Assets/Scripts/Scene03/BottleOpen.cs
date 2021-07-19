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

    public void ZoomToCokeBottle(){
        Vector3 targetPosition = targetObject.transform.position + new Vector3 (0.0f, 1.0f, 0.0f);
        var rotation = Quaternion.LookRotation(targetPosition - _camera.transform.position);
        _camera.transform.DORotateQuaternion(rotation, 0.5f); // キャップを向く
        _camera.DOFieldOfView(10, 0.5f).SetEase(Ease.InBack); // カメラzoom
        StartCoroutine(DelayCoroutine(0.5f)); 
        openButton.SetActive(true);
    }

    public void RemoveCap(){


    }

    
    private IEnumerator DelayCoroutine(float waittime){
        yield return new WaitForSeconds(waittime);
    }
}
