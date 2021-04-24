using UnityEngine;

public class Damage : MonoBehaviour
{
   [SerializeField] private Player player;
   [SerializeField] private Transform characterTransform;
   [SerializeField] private StunBehaviour stunBehaviour;
   [SerializeField] private float health = 1;
   [SerializeField] private float healthCapacity = 5;

   public float Health => health;
   public float HealthCapacity => healthCapacity;

   private void Awake()
   {
      characterTransform = transform.parent;
      stunBehaviour = characterTransform.GetComponentInChildren<StunBehaviour>();
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
      foreach(var myDamager in characterTransform.GetComponentsInChildren<Damager>())
         if (myDamager == damager)
            return;
      TakeDamage(damager);
   }

   private void TakeDamage(Damager damager)
   {
      health -= damager.Damage;
      if (stunBehaviour)
         stunBehaviour.Stun(damager);
      if (health <= 0)
         Destroy(characterTransform.gameObject);
   }
}