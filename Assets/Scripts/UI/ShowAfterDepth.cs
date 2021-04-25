using UnityEngine;

public class ShowAfterDepth : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject uiElement;
    [SerializeField] private float depthToShow;
    [SerializeField] private bool showIfGotAirTank;
    [SerializeField] private bool showIfGotCoolingWisp;

    private float CurrentDepth => player ? player.maxDepth ? player.maxDepth.Value : 0 : 0;
    private bool HasAirTank => player && player.oxygen && player.oxygen.AirTankCount > 0;
    private bool HasCoolingWisp => player && player.heat && player.heat.CoolWispCount > 0;

    private void Update()
    {
        var show = CurrentDepth >= depthToShow;
        show |= showIfGotAirTank && HasAirTank;
        show |= showIfGotCoolingWisp && HasCoolingWisp;
        if (!show) return;
        uiElement.SetActive(true);
        Destroy(this);
    }
}
