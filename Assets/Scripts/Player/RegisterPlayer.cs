using UnityEngine;

public class RegisterPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform playerTransform;

    private void OnEnable()
    {
        playerTransform = transform.parent;
        player.gameObject = playerTransform.gameObject;
        player.transform = playerTransform;
    }

    private void OnDisable()
    {
        player.gameObject = null;
        player.transform = null;
    }
}