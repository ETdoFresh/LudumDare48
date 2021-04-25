using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI qtyTextMesh;

    private float Oxygen => player ? player.oxygen ? player.oxygen.Value : 0 : 0;
    private float OxygenCapacity => player ? player.oxygen ? player.oxygen.Capacity : 1 : 1;
    private float AirTankCount => player ? player.oxygen ? player.oxygen.AirTankCount : 0 : 0;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = Oxygen / OxygenCapacity;
        qtyTextMesh.text = $"x{AirTankCount}";
    }
}