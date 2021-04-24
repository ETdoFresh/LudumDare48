using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private bool isLeft;

    public bool IsLeft => isLeft;
    public bool IsRight => !isLeft;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.x < -0.1f)
            isLeft = true;
        else if (_rigidbody2D.velocity.x > 0.1f)
            isLeft = false;
    }
}