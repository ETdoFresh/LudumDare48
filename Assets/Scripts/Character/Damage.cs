using UnityEngine;

public class Damage : MonoBehaviour
{
   [SerializeField] private Player player;
   [SerializeField] private Transform characterTransform;
   [SerializeField] private float health = 1;
   [SerializeField] private float healthCapacity = 5;
   public float Health => health;
   public float HealthCapacity => healthCapacity;

   private void Awake()
   {
      characterTransform = transform.parent;
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
      TakeDamage(damager);
   }

   private void TakeDamage(Damager damager)
   {
      health -= damager.Damage;
      if (health <= 0)
         Destroy(characterTransform.gameObject);
   }
}