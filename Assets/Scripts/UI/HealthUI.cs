using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;

    private float Health => player ? player.damage ? player.damage.Health : 0 : 0;
    private float HealthCapacity => player ? player.damage ? player.damage.HealthCapacity : 1 : 1;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = Health / HealthCapacity;
    }
}
