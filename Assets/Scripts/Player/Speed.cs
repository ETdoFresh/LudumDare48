using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float value = 1;
    [SerializeField] private float capacity = 5;
    public float Value => value;
    public float Capacity => capacity;
    
    private void OnEnable()
    {
        player.speed = this;
    }

    private void OnDisable()
    {
        if (player.speed == this)
            player.speed = null;
    }

    public void Add(float amount)
    {
        value += amount;
    }
}