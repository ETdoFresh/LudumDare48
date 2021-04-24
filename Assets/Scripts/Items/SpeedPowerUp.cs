using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedAmount = 0.5f;
    [SerializeField] private GameObject powerUpGameObject;
    [SerializeField] private AudioPlayer collectSound;

    private void Awake()
    {
        powerUpGameObject = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var collector = other.GetComponent<Collector>();
        if (!collector) return;
        Collect(collector);
        Destroy(powerUpGameObject);
    }

    private void Collect(Component collector)
    {
        var speed = collector.transform.parent.GetComponentInChildren<Speed>();
        if (speed) speed.Add(speedAmount);
        if (collectSound) collectSound.Play();
    }
}