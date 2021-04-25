using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private WaterDetector waterDetector;
    [SerializeField] private Damage damage;
    [SerializeField] private float value;
    [SerializeField] private float capacity = 1;
    [SerializeField] private float reductionRate = 1f/10;
    [SerializeField] private float increaseRate = 1f;
    [SerializeField] private float damageRate = 1f/10;
    public float Value => value;
    public float Capacity => capacity;
    private bool InWater => waterDetector && waterDetector.InWater;
    private bool NoOxygen => value <= 0;

    private void Awake()
    {
        characterTransform = transform.parent;
        waterDetector = characterTransform.GetComponentInChildren<WaterDetector>();
        damage = characterTransform.GetComponentInChildren<Damage>();
    }

    private void Update()
    {
        if (InWater) LowerOxygenLevels();
        if (!InWater) IncreaseOxygenLevels();
        if (NoOxygen) TakeDamage();
    }

    private void OnEnable()
    {
        player.oxygen = this;
    }

    private void OnDisable()
    {
        if (player.oxygen == this)
            player.oxygen = null;
    }

    private void LowerOxygenLevels()
    {
        value -= reductionRate * Time.deltaTime;
        value = Mathf.Max(value, 0);
    }

    private void IncreaseOxygenLevels()
    {
        value += increaseRate * Time.deltaTime;
        value = Mathf.Min(value, capacity);
    }

    private void TakeDamage()
    {
        damage.WaterDamage(damageRate * Time.deltaTime);
    }
}