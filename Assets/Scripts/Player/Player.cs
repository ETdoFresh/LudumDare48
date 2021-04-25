using UnityEngine;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    public GameObject gameObject;
    public Transform transform;
    public Damage damage;
    public Stamina stamina;
    public Oxygen oxygen;
    public Speed speed;
    public State state;
    public TimeAlive timeAlive;
    public MaxDepth maxDepth;
    public Heat heat;
}