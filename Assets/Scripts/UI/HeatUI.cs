using UnityEngine;
using UnityEngine.UI;

public class HeatUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;

    private float Heat => player ? player.heat ? player.heat.Value : 0 : 0;
    private float HeatCapacity => player ? player.heat ? player.heat.Capacity : 1 : 1;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = Heat / HeatCapacity;
    }
}