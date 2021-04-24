using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damage = 1;

    public float Damage => damage;
}