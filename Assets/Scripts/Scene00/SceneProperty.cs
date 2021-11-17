using System;
using UnityEngine;
using UniRx;

public class SceneProperty : MonoBehaviour
{
    public bool cacheable;
    public string sceneName { get { return gameObject.scene.name; } }

    private Subject<Unit> sceneEnabledStream = new Subject<Unit>();
    public IObservable<Unit> sceneEnabledAsObservable
    {
        get { return sceneEnabledStream.AsObservable(); }
    }

    private Subject<Unit> sceneDisabledStream = new Subject<Unit>();
    public IObservable<Unit> sceneDisabledAsObservable
    {
        get { return sceneDisabledStream.AsObservable(); }
    }

    public void Disable()
    {
        sceneDisabledStream.OnNext(Unit.Default);
        foreach (var root in gameObject.scene.GetRootGameObjects())
        {
            root.SetActive(false);
        }
    }

    public void Enable()
    {
        sceneEnabledStream.OnNext(Unit.Default);
        foreach (var root in gameObject.scene.GetRootGameObjects())
        {
            root.SetActive(true);
        }
    }
}
