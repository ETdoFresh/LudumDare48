using UnityEngine;

public class FlipScaleWithDirection : MonoBehaviour
{
    private Direction _direction;

    private void Awake()
    {
        _direction = transform.parent.GetComponentInChildren<Direction>();
    }

    private void Update()
    {
        if (_direction.IsLeft) FlipLeft();
        else if (_direction.IsRight) FlipRight();
    }

    private void FlipLeft()
    {
        var scale = transform.localScale;
        scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    
    private void FlipRight()
    {
        var scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
