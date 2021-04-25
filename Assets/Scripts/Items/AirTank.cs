using UnityEngine;

public class AirTank : MonoBehaviour
{
    [SerializeField] private GameObject myGameObject;
    [SerializeField] private AudioPlayer collectSound;

    private void Awake()
    {
        myGameObject = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var collector = other.GetComponent<Collector>();
        if (!collector) return;
        Collect(collector);
        Destroy(myGameObject);
    }

    private void Collect(Component collector)
    {
        var oxygen = collector.transform.parent.GetComponentInChildren<Oxygen>();
        if (oxygen) oxygen.AddAirTank();
        if (collectSound) collectSound.Play();
    }
}