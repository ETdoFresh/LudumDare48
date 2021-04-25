using System;
using UnityEngine;

public class Heat : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Damage damage;
    [SerializeField] private float value = 0;
    [SerializeField] private float capacity = 1;
    [SerializeField] private float startHeatLevel = -100;
    [SerializeField] private float maxHeatLevel = -200;
    [SerializeField] private float startHeatRate = 1f / 10;
    [SerializeField] private float maxHeatRate = 1;
    [SerializeField] private float coolRate = 1;
    [SerializeField] private float damageRate = 1;
    [SerializeField] private int coolingWispCount;

    public float Value => value;
    public float Capacity => capacity;
    public float CoolWispCount => coolingWispCount;
    private bool IsBurning => value >= capacity;

    private void Awake()
    {
        characterTransform = transform.parent;
        damage = characterTransform.GetComponentInChildren<Damage>();
    }

    private void OnEnable()
    {
        player.heat = this;
    }

    private void OnDisable()
    {
        if (player.heat == this)
            player.heat = null;
    }

    private void Update()
    {
        var inHeat = transform.position.y < startHeatLevel;
        if (inHeat) IncreaseHeat();
        if (!inHeat) DecreaseHeat();
        if (IsBurning) UseCoolingWisp();
        if (IsBurning) TakeDamage();

    }

    private void IncreaseHeat()
    {
        var currentLevel = transform.position.y;
        var rate = maxHeatRate;
        if (currentLevel >= maxHeatLevel)
        {
            var delta = currentLevel - startHeatLevel;
            var levelRange = maxHeatLevel - startHeatLevel;
            var rateRange = maxHeatRate - startHeatRate;
            rate = startHeatRate + rateRange * delta / levelRange;
        }

        value += rate * Time.deltaTime;
        value = Mathf.Min(value, capacity);
    }

    private void DecreaseHeat()
    {
        value -= coolRate * Time.deltaTime;
        value = Mathf.Max(value, 0);
    }

    private void UseCoolingWisp()
    {
        if (coolingWispCount <= 0) return;
        value = 0;
        coolingWispCount--;
    }

    private void TakeDamage()
    {
        damage.EnvironmentDamage(damageRate * Time.deltaTime);
    }

    public void AddCoolingWisp()
    {
        coolingWispCount++;
    }
}