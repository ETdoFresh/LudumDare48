using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private StunBehaviour stunBehaviour;
    [SerializeField] private float health = 1;
    [SerializeField] private float healthCapacity = 5;
    [SerializeField] private DropBehaviour dropBehaviour;
    [SerializeField] private UnityEvent dead;

    public float Health => health;
    public float HealthCapacity => healthCapacity;

    private void Awake()
    {
        characterTransform = transform.parent;
        stunBehaviour = characterTransform.GetComponentInChildren<StunBehaviour>();
        dropBehaviour = characterTransform.GetComponentInChildren<DropBehaviour>();
    }

    private void OnEnable()
    {
        if (player) player.damage = this;
    }

    private void OnDisable()
    {
        if (player && player.damage == this)
            player.damage = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damager = other.GetComponent<Damager>();
        if (!damager) return;
        foreach (var myDamager in characterTransform.GetComponentsInChildren<Damager>())
            if (myDamager == damager)
                return;
        TakeDamage(damager);
    }

    private void TakeDamage(Damager damager)
    {
        health -= damager.Damage;
        if (stunBehaviour)
            stunBehaviour.Stun(damager);

        if (health > 0) return;
        dead.Invoke();
        if (dropBehaviour)
            dropBehaviour.Drop();
        Destroy(characterTransform.gameObject);
    }

    public void EnvironmentDamage(float amount)
    {
        health -= amount;
        if (health > 0) return;
        dead.Invoke();
        Destroy(characterTransform.gameObject);
    }
}