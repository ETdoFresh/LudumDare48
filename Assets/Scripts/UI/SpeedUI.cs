using UnityEngine;
using UnityEngine.UI;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;

    private float Speed => player ? player.speed ? player.speed.Value : 1 : 1;
    private float SpeedCapacity => player ? player.speed ? player.speed.Capacity : 5 : 5;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = Speed / SpeedCapacity;
    }
}
