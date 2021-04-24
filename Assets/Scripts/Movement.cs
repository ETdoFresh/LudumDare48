using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LocalInput localInput;
    [SerializeField] private float force = 1;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        var forceVector = force * localInput.horizontal * Vector2.right;
        _rigidbody2D.AddForce(forceVector);
    }
}
