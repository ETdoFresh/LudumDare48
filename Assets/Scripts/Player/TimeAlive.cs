using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAlive : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Score score;
    [SerializeField] private float value;
    public float Value => value;
    
    private void OnEnable()
    {
        player.timeAlive = this;
        score.time = value;
    }

    private void OnDisable()
    {
        if (player.timeAlive == this)
            player.timeAlive = null;
    }

    private void Update()
    {
        value += Time.deltaTime;
        score.time = value;
    }
}
