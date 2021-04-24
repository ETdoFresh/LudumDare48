using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LocalInput localInput;
    [SerializeField] private float force = 1;
    private Transform _characterTransform;
    private Rigidbody2D _rigidbody2D;
    private Speed _speed;

    private void Awake()
    {
        _characterTransform = transform.parent;
        _rigidbody2D = _characterTransform.GetComponentInChildren<Rigidbody2D>();
        _speed = _characterTransform.GetComponentInChildren<Speed>();
    }

    private void FixedUpdate()
    {
        var forceVector = force * localInput.horizontal * _speed.Value * Vector2.right;
        _rigidbody2D.AddForce(forceVector);
    }
}
