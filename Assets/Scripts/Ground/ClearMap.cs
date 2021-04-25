using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMap : MonoBehaviour
{
    [SerializeField] private Map map;

    private void OnEnable()
    {
        map.ClearDigs();
    }

    private void OnDisable()
    {
        map.ClearDigs();
    }
}