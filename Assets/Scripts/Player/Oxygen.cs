using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float value;
    public float Value => value;
    
    private void OnEnable()
    {
        player.oxygen = this;
    }

    private void OnDisable()
    {
        if (player.oxygen == this)
            player.oxygen = null;
    }
}