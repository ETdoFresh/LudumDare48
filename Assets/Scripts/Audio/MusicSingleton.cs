using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    private static MusicSingleton singleton;

    private void OnEnable()
    {
        if (singleton)
        {
            Destroy(gameObject);
            return;
        }

        singleton = this;
        DontDestroyOnLoad(gameObject);
    }
}
