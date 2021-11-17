using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using UniRx;
using UnityEngine.SceneManagement;

public class SceneManagerWithCache : MonoBehaviour
{
    [SerializeField]
    private int sceneCacheCapacity = 3;

    public ReactiveCollection<SceneProperty> scenes = new ReactiveCollection<SceneProperty>();

    private void Awake()
    {
        var sceneAddAsObservable = scenes.ObserveAdd()
                                         .Publish()
                                         .RefCount();
        sceneAddAsObservable
            .Where(s => s.Index >= sceneCacheCapacity)
            .Subscribe(s =>
            {
                var unloadScene = scenes.First();
                scenes.Remove(unloadScene);
                SceneManager.UnloadSceneAsync(unloadScene.gameObject.scene);
            });

        sceneAddAsObservable
            .Select(currentScene => scenes.Where(s => !(s.cacheable | s.Equals(currentScene.Value))))
            .Where(unCachedScens => unCachedScens.Count() > 0)
            .Subscribe(unCachedScens =>
            {
                for(int i = 0; i < unCachedScens.Count(); i++)
                {
                    var s = unCachedScens.ToList()[i];
                    scenes.Remove(s);
                    SceneManager.UnloadSceneAsync(s.sceneName);
                }
            });
    }

    public IObservable<SceneProperty> LoadMergedScene(string baseSceneName, bool useCache, params string[] subSceneNames)
    {
        if (useCache)
        {
            IObservable<SceneProperty> propertyObservable = GetCacheScene(baseSceneName);
            if (propertyObservable != null)
            {
                return propertyObservable;
            }
        }

        return LoadScene(baseSceneName, useCache)
            .Take(1)
            .Select(p => p.gameObject.scene)
            .Concat(Observable.FromCoroutine<Scene>(observer => LoadSubSceneCoroutine(observer, subSceneNames)))
            .Do(loadedScene =>
            {
                var baseScene = SceneManager.GetSceneByName(baseSceneName);
                SceneManager.MergeScenes(loadedScene, baseScene);
            })
            .Select(_ => scenes.Last(s => s.sceneName == baseSceneName));
    }

    private IEnumerator LoadSubSceneCoroutine(IObserver<Scene> observer, params string[] subScenes)
    {
        foreach (var s in subScenes)
        {
            yield return SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive)
                .AsObservable()
                .ToYieldInstruction();
            observer.OnNext(SceneManager.GetSceneByName(s));
        }
        observer.OnCompleted();
    }

    public IObservable<SceneProperty> LoadScene(string name, bool useCache = true)
    {
        if (useCache)
        {
            IObservable<SceneProperty> propertyObservable = GetCacheScene(name);
            if (propertyObservable != null)
            {
                return propertyObservable;
            }
        }

        return SceneLoadedAsObservable(name);
    }

    private IObservable<SceneProperty> GetCacheScene(string sceneName)
    {
        var scene = scenes.LastOrDefault(s => s.sceneName == sceneName && s.cacheable);
        if (scene == null)
        {
            return null;
        }
        scene.Enable();
        var beforeScene = scenes.Last();
        if (beforeScene != null)
        {
            beforeScene.Disable();
        }
        scenes.Remove(scene);
        scenes.Add(scene);
        return Observable.Return<SceneProperty>(scene);
    }

    private IObservable<SceneProperty> SceneLoadedAsObservable(string name)
    {
        return SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive)
                  .AsObservable()
                  .Select(_ => SceneManager.GetSceneByName(name))
                  .Select(scene => scene.GetRootGameObjects().First().GetComponent<SceneProperty>())
                  .Do(property =>
                  {
                      var beforeScene = scenes.LastOrDefault();
                      if (beforeScene != null)
                      {
                          beforeScene.Disable();
                      }
                      scenes.Add(property);
                  });
    }
}
