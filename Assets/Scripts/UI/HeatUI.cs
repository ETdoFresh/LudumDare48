using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeatUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI qtyTextMesh;

    private float Heat => player ? player.heat ? player.heat.Value : 0 : 0;
    private float HeatCapacity => player ? player.heat ? player.heat.Capacity : 1 : 1;
    private float CoolingWispCount => player ? player.heat ? player.heat.CoolWispCount : 0 : 0;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = Heat / HeatCapacity;
        qtyTextMesh.text = $"x{CoolingWispCount}";
    }
}