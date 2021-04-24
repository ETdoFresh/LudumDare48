using UnityEngine;

public class Damage : MonoBehaviour
{
   [SerializeField] private Transform characterTransform;
   [SerializeField] private float health = 1;

   private void Awake()
   {
      characterTransform = transform.parent;
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