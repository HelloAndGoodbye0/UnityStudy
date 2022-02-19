using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> where T : Singleton<T>, new()
{
    private readonly static object threadLockObj = new object();
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (threadLockObj)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }

}

