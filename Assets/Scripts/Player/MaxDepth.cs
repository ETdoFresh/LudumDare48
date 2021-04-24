using UnityEngine;

public class MaxDepth : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float value;
    public float Value => value;
    
    private void OnEnable()
    {
        player.maxDepth = this;
    }

    private void OnDisable()
    {
        if (player.maxDepth == this)
            player.maxDepth = null;
    }

    private void Update()
    {
        value = Mathf.Max(value, -transform.position.y);
    }
}
