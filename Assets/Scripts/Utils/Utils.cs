using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public static class Utils
{
    public static T GetPrefabByName<T>(string prefabName) where T: class
    {
        return Resources.Load( "Prefabs/" + prefabName, typeof( T ) ) as T;
    }

    public static async UniTask MultipleExecutionAsync ( int amountOfTimesToRepeat, float interval, UnityAction action )
    {
        for (int i = 0; i < amountOfTimesToRepeat; i++)
        {
            await UniTask.Delay( TimeSpan.FromSeconds( interval ) );
            action();
        }
    }

    public static async UniTask ExecuteActionOverSeconds (float totalTime,  UnityAction action)
    {
        float elapsedTime = 0;
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
            action();
        }
    }
}
