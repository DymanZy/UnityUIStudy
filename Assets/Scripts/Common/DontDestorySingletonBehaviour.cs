using System;
using System.Collections.Generic;
using UnityEngine;


public class DontDestorySingletonBehaviour<T> : ObjectBaseBehavior where T : DontDestorySingletonBehaviour<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null) return instance;

            instance = (new GameObject("DontDestroy_" + typeof(T).Name)).AddComponent<T>();
            DontDestroyOnLoad(instance.gameObject);
            return instance;
        }
    }
}

