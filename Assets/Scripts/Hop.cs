using UnityEngine;

public class Hop : MonoBehaviour
{
    [SerializeField] private LocalInput localInput;
    [SerializeField] private float hopForce;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (localInput.jumpPressed)
            _rigidbody2D.AddForce(hopForce * Vector2.up, ForceMode2D.Impulse);
    }
}
