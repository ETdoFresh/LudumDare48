using System;
using UnityEngine;

[CreateAssetMenu]
public class LocalInput : ScriptableObject
{
    public float horizontal;
    public float vertical;
    public bool jumpPressed;
    public bool attackPressed;
}