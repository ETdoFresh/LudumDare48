using System;
using UnityEngine;

public class WaterDetector : MonoBehaviour
{
    [SerializeField] private bool inWater;
    [SerializeField] private float waterLevel = -50.25f;
    [SerializeField] private Transform characterTransform;

    public bool InWater => inWater;

    private void Awake()
    {
        characterTransform = transform.parent;
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (!other.GetComponent<Water>()) return;
    //     inWater = true;
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (!other.GetComponent<Water>()) return;
    //     inWater = false;
    // }
    private void Update()
    {
        inWater = transform.position.y < waterLevel;
    }
}