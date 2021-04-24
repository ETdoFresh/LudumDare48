using Cinemachine;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        virtualCamera.Follow = player.transform;
    }
}
