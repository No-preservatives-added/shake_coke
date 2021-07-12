using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMover : MonoBehaviour
{
    // インペクターから設定する
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoomToCokeBottle()
    {
        Vector3 targetPosition = targetObject.transform.position + new Vector3 (0.0f, 0.5f, 0.0f);
        var rotation = Quaternion.LookRotation(targetPosition - _camera.transform.position);
        _camera.transform.DORotateQuaternion(rotation, 0.5f);
        _camera.DOFieldOfView(15, 0.5f);
    }
}
