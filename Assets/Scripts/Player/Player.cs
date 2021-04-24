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

    public float HealthValue => damage ? damage.Health : 0;
    public float HealthCapacityValue => damage ? damage.HealthCapacity : 1;
    public float StaminaValue => stamina ? stamina.Value : 0;
    public float OxygenValue => oxygen ? oxygen.Value : 0;
    public float SpeedValue => speed ? speed.Value : 0;
    public State.StateName StateValue => state ? state.Value : State.StateName.Normal;
}