using UnityEngine;

public class State : MonoBehaviour
{
    public enum StateName
    {
        Normal,
        Stunned,
        Dead
    }

    [SerializeField] private Player player;
    [SerializeField] private StateName value;
    public StateName Value => value;
    
    private void OnEnable()
    {
        player.state = this;
    }

    private void OnDisable()
    {
        if (player.state == this)
            player.state = null;
    }
}