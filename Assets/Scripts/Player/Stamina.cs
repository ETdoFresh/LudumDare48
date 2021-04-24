using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float value;
    public float Value => value;
    
    private void OnEnable()
    {
        player.stamina = this;
    }

    private void OnDisable()
    {
        if (player.stamina == this)
            player.stamina = null;
    }
}